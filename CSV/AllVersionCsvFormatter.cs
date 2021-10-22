using PimsExporter.Entities;

namespace CSV
{
    public class AllVersionCsvFormatter : DocumentFormatterBase<AllVersion>
    {
        public AllVersionCsvFormatter() : base(",")
        {
            Columns = new[]
            {
                new ColumnFormatter<AllVersion>("Comment", r => r.Comment)
            };
        }
    }
}