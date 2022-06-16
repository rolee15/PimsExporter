using System.Globalization;
using Domain.Entities;

namespace CSV.Formatters
{
    public class VersionRelatedOmItemFormatter : DocumentFormatterBase<VersionRelatedOmItem>
    {
        public VersionRelatedOmItemFormatter() : base(CultureInfo.CurrentCulture.TextInfo.ListSeparator)
        {
            Columns = new[]
            {
                new ColumnFormatter<VersionRelatedOmItem>(nameof(VersionRelatedOmItem.OmItemNumber), r => r.OmItemNumber),
                new ColumnFormatter<VersionRelatedOmItem>(nameof(VersionRelatedOmItem.VersionNumber), r => r.VersionNumber),
                new ColumnFormatter<VersionRelatedOmItem>(nameof(VersionRelatedOmItem.LinkType), r => r.LinkType),
                new ColumnFormatter<VersionRelatedOmItem>(nameof(VersionRelatedOmItem.ShortDescription),
                    r => r.ShortDescription),
                new ColumnFormatter<VersionRelatedOmItem>(nameof(VersionRelatedOmItem.PimsLink), r => r.PimsLink)
            };
        }
    }
}