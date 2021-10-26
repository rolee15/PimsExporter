using System.Globalization;
using PimsExporter.Entities;

namespace CSV
{
    public class AllVersionCsvFormatter : DocumentFormatterBase<AllVersion>
    {
        public AllVersionCsvFormatter() : base(CultureInfo.CurrentCulture.TextInfo.ListSeparator)
        {
            //TODO could do this in the base class with reflection
            Columns = new[]
            {
                new ColumnFormatter<AllVersion>("PortfolioUnit", r => r.PortfolioUnit),
                new ColumnFormatter<AllVersion>("OmItemName", r => r.OmItemName),
                new ColumnFormatter<AllVersion>("OmItemId", r => r.OmItemId),
                new ColumnFormatter<AllVersion>("PimsId", r => r.PimsId),
                new ColumnFormatter<AllVersion>("VersionName", r => r.VersionName),
                new ColumnFormatter<AllVersion>("FullVersionId", r => r.FullVersionId),
                new ColumnFormatter<AllVersion>("VersionOfferingType", r => r.VersionOfferingType),
                new ColumnFormatter<AllVersion>("CurrentOlmPhase", r => r.CurrentOlmPhase),
                new ColumnFormatter<AllVersion>("PuReleaseAssignment", r => r.PuReleaseAssignment),
                new ColumnFormatter<AllVersion>("BssReleaseAssignment", r => r.BssReleaseAssignment),
                new ColumnFormatter<AllVersion>("OssReleaseAssignment", r => r.OssReleaseAssignment),
                new ColumnFormatter<AllVersion>("Comment", r => r.Comment),
            };
        }
    }
}