using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV.Formatters
{
    class RelatedOMItemCsvFormatter : DocumentFormatterBase<RelatedOmItem>
    {
        public RelatedOMItemCsvFormatter() : base(CultureInfo.CurrentCulture.TextInfo.ListSeparator)
        {
            Columns = new[]
            {
                new ColumnFormatter<RelatedOmItem>(nameof(RelatedOmItem.OmItemNumber), r => r.OmItemNumber),
                new ColumnFormatter<RelatedOmItem>(nameof(RelatedOmItem.LinkType), r => r.LinkType),
                new ColumnFormatter<RelatedOmItem>(nameof(RelatedOmItem.ShortDescription), r => r.ShortDescription),
                new ColumnFormatter<RelatedOmItem>(nameof(RelatedOmItem.PimsLink), r => r.PimsLink),
            };
        }
    }
}
