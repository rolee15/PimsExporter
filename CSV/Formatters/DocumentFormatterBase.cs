using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Domain.Entities;

namespace CSV.Formatters
{
    public abstract class DocumentFormatterBase<T>
    {
        private readonly string _separator;

        protected DocumentFormatterBase(string separator)
        {
            _separator = separator;
        }

        protected IEnumerable<ColumnFormatter<T>> Columns { get; set; }

        public Stream FormatStream(IEnumerable<T> rows)
        {
            var stream = new MemoryStream();

            using (var writer = new StreamWriter(stream, Encoding.UTF8, 4096, true))
            {
                PrintHeaderAsync(writer);

                foreach (var row in rows) PrintDataAsync(writer, row);
            }

            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }

        private void PrintHeaderAsync(TextWriter writer)
        {
            var header = string.Join(_separator, Columns.Select(c => QuoteFields(c.Header)));
            writer.WriteLine(header);
        }

        private void PrintDataAsync(TextWriter writer, T row)
        {
            var data = string.Join(_separator, Columns.Select(c => QuoteFields(c.Formatter(row))));
            writer.WriteLine(data);
        }

        private string QuoteFields(string value)
        {
            if (value is null) return string.Empty;
            return value.Contains("\"") ? $"\"{value.Replace("\"", "\"\"")}\"" : $"\"{value}\"";
        }


        protected sealed class ColumnFormatter<TRow> where TRow : T
        {
            private const string DateFormat = "O";
            private const string IntFormat = "{0}";
            private const string FloatFormat = "{0:0.00}";
            private const string DecimalFormat = "{0:0.0000}";

            private readonly CultureInfo _culture = CultureInfo.GetCultureInfo("en-US");

            public ColumnFormatter(string header, Func<TRow, string> getter)
            {
                Header = header ?? throw new ArgumentNullException(nameof(header));
                if (getter is null) throw new ArgumentNullException(nameof(getter));
                Formatter = getter;
            }

            public ColumnFormatter(string header, Func<TRow, bool> getter)
            {
                Header = header ?? throw new ArgumentNullException(nameof(header));
                if (getter is null) throw new ArgumentNullException(nameof(getter));
                Formatter = r => getter(r).ToString();
            }

            public ColumnFormatter(string header, Func<TRow, int> getter)
            {
                Header = header ?? throw new ArgumentNullException(nameof(header));
                if (getter is null) throw new ArgumentNullException(nameof(getter));
                Formatter = r => string.Format(_culture, IntFormat, getter(r));
            }

            public ColumnFormatter(string header, Func<TRow, int?> getter)
            {
                Header = header ?? throw new ArgumentNullException(nameof(header));
                if (getter is null) throw new ArgumentNullException(nameof(getter));
                Formatter = r => string.Format(_culture, IntFormat, getter(r));
            }

            public ColumnFormatter(string header, Func<TRow, double> getter)
            {
                Header = header ?? throw new ArgumentNullException(nameof(header));
                if (getter is null) throw new ArgumentNullException(nameof(getter));
                Formatter = r => string.Format(_culture, FloatFormat, getter(r));
            }

            public ColumnFormatter(string header, Func<TRow, double?> getter)
            {
                Header = header ?? throw new ArgumentNullException(nameof(header));
                if (getter is null) throw new ArgumentNullException(nameof(getter));
                Formatter = r => getter(r).HasValue ? string.Format(_culture, FloatFormat, getter(r)) : string.Empty;
            }

            public ColumnFormatter(string header, Func<TRow, decimal> getter)
            {
                Header = header ?? throw new ArgumentNullException(nameof(header));
                if (getter is null) throw new ArgumentNullException(nameof(getter));
                Formatter = r => string.Format(_culture, FloatFormat, getter(r));
            }

            public ColumnFormatter(string header, Func<TRow, decimal?> getter)
            {
                Header = header ?? throw new ArgumentNullException(nameof(header));
                if (getter is null) throw new ArgumentNullException(nameof(getter));
                Formatter = r => string.Format(_culture, DecimalFormat, getter(r));
            }

            public ColumnFormatter(string header, Func<TRow, DateTime> getter)
            {
                Header = header ?? throw new ArgumentNullException(nameof(header));
                if (getter is null) throw new ArgumentNullException(nameof(getter));
                Formatter = r => getter(r).ToString(DateFormat);
            }

            public ColumnFormatter(string header, Func<TRow, DateTime?> getter)
            {
                Header = header ?? throw new ArgumentNullException(nameof(header));
                if (getter is null) throw new ArgumentNullException(nameof(getter));
                Formatter = r => getter(r).HasValue ? getter(r).Value.ToString(DateFormat) : null;
            }

            public ColumnFormatter(string header, Func<TRow, User> getter)
            {
                Header = header ?? throw new ArgumentNullException(nameof(header));
                if (getter is null) throw new ArgumentNullException(nameof(getter));
                Formatter = r => getter(r)?.Name ?? getter(r)?.Email;
            }

            public ColumnFormatter(string header, Func<TRow, IEnumerable<string>> getter)
            {
                Header = header ?? throw new ArgumentNullException(nameof(header));
                if (getter is null) throw new ArgumentNullException(nameof(getter));
                Formatter = r =>
                {
                    var collection = getter(r);
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in collection)
                        sb.Append(item + "; ");

                    if(sb.Length>0) sb.Length -= 1;
                    return sb.ToString();
                };
            }

            public string Header { get; }
            public Func<TRow, string> Formatter { get; }
        }
    }
}