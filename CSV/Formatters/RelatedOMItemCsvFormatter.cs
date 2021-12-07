using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV.Formatters
{
    class RelatedOMItemCsvFormatter : DocumentFormatterBase<RelatedOMItem>
    {
        public RelatedOMItemCsvFormatter() : base(CultureInfo.CurrentCulture.TextInfo.ListSeparator)
        {
            Columns = new[]
            {
                new ColumnFormatter<RelatedOMItem>(nameof(RelatedOMItem.OmItemNumber), r => r.OmItemNumber),
                new ColumnFormatter<RelatedOMItem>(nameof(RelatedOMItem.LinkType), r => r.LinkType),
                new ColumnFormatter<RelatedOMItem>(nameof(RelatedOMItem.ShortDescription), r => r.ShortDescription),
                new ColumnFormatter<RelatedOMItem>(nameof(RelatedOMItem.PimsLink), r => r.PimsLink),
            };
        }
    }
}
