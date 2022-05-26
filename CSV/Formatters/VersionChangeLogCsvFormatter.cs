using System.Globalization;
using Domain.Entities;

namespace CSV.Formatters
{
    internal class VersionChangeLogCsvFormatter : DocumentFormatterBase<VersionChangeLog>
    {
        public VersionChangeLogCsvFormatter() : base(CultureInfo.CurrentCulture.TextInfo.ListSeparator)
        {
            Columns = new[]
            {
                new ColumnFormatter<VersionChangeLog>(nameof(VersionChangeLog.OmItemNumber), r => r.OmItemNumber),
                new ColumnFormatter<VersionChangeLog>(nameof(VersionChangeLog.VersionNumber), r => r.VersionNumber),
                new ColumnFormatter<VersionChangeLog>(nameof(VersionChangeLog.Event), r => r.Event),
                new ColumnFormatter<VersionChangeLog>(nameof(VersionChangeLog.DateAndTimeOfChange),
                    r => r.DateAndTimeOfChange),
                new ColumnFormatter<VersionChangeLog>(nameof(VersionChangeLog.User), r => r.User),
                new ColumnFormatter<VersionChangeLog>(nameof(VersionChangeLog.TypeOfChange), r => r.TypeOfChange),
                new ColumnFormatter<VersionChangeLog>(nameof(VersionChangeLog.ChangeSection), r => r.ChangeSection)
            };
        }
    }
}