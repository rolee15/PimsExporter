using System.Globalization;
using Domain.Entities;

namespace CSV.Formatters
{
    internal class RelatedOmItemCsvFormatter : DocumentFormatterBase<RelatedOmItem>
    {
        public RelatedOmItemCsvFormatter() : base(CultureInfo.CurrentCulture.TextInfo.ListSeparator)
        {
            Columns = new[]
            {
                new ColumnFormatter<RelatedOmItem>(nameof(RelatedOmItem.OmItemNumber), r => r.OmItemNumber),
                new ColumnFormatter<RelatedOmItem>(nameof(RelatedOmItem.LinkType), r => r.LinkType),
                new ColumnFormatter<RelatedOmItem>(nameof(RelatedOmItem.ShortDescription), r => r.ShortDescription),
                new ColumnFormatter<RelatedOmItem>(nameof(RelatedOmItem.PimsLink), r => r.PimsLink)
            };
        }
    }
}