using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace CSV
{
    public abstract class DocumentFormatterBase<T>
    {
        private readonly string _separator;

        protected DocumentFormatterBase(string separator)
        {
            _separator = separator;
        }

        protected IEnumerable<ColumnFormatter<T>> Columns { get; set; }

        public Stream FormatAsync(IEnumerable<T> rows)
        {
            var stream = new MemoryStream();

            using (var writer = new StreamWriter(stream, Encoding.UTF8, 4096, true))
            {
                PrintHeaderAsync(writer);

                foreach (var row in rows)
                {
                    PrintDataAsync(writer, row);
                }
            }
            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }

        private void PrintHeaderAsync(TextWriter writer)
        {
            var header = string.Join(_separator, Columns.Select(c => c.Header));
            writer.WriteLine(header);
        }

        private void PrintDataAsync(TextWriter writer, T row)
        {
            var data = string.Join(_separator, Columns.Select(c => c.Formatter(row)));
            writer.WriteLine(data);
        }

        protected sealed class ColumnFormatter<TRow> where TRow : T
        {
            private const string DateFormat = "yyyy-MM-dd";

            private const string FloatFormat = "{0:0.00}";
            private const string DecimalFormat = "{0:0.0000}";

            private readonly CultureInfo _culture = CultureInfo.GetCultureInfo("en-GB");

            public ColumnFormatter(string header, Func<TRow, string> formatter)
            {
                Header = header ?? throw new ArgumentNullException(nameof(header));
                Formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
            }

            public ColumnFormatter(string header, Func<TRow, double> formatter)
            {
                Header = header ?? throw new ArgumentNullException(nameof(header));
                if (formatter is null) throw new ArgumentNullException(nameof(formatter));
                Formatter = r => string.Format(_culture, FloatFormat, formatter(r));
            }

            public ColumnFormatter(string header, Func<TRow, decimal> formatter)
            {
                Header = header ?? throw new ArgumentNullException(nameof(header));
                if (formatter is null) throw new ArgumentNullException(nameof(formatter));
                Formatter = r => string.Format(_culture, FloatFormat, formatter(r));
            }

            public ColumnFormatter(string header, Func<TRow, decimal?> formatter)
            {
                Header = header ?? throw new ArgumentNullException(nameof(header));
                if (formatter is null) throw new ArgumentNullException(nameof(formatter));
                Formatter = r => string.Format(_culture, DecimalFormat, formatter(r));
            }

            public ColumnFormatter(string header, Func<TRow, DateTime> formatter)
            {
                Header = header ?? throw new ArgumentNullException(nameof(header));
                if (formatter is null) throw new ArgumentNullException(nameof(formatter));
                Formatter = r => formatter(r).ToString(DateFormat);
            }

            public string Header { get; }
            public Func<TRow, string> Formatter { get; }
        }


    }

}