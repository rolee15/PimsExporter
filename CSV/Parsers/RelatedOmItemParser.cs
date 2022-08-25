using Domain.Entities;
using System;

namespace CSV.Parsers
{
    internal class RelatedOmItemParser : CsvParser<RelatedOmItem>
    {
        public RelatedOmItemParser()
        {
            Parsers = new Action<RelatedOmItem, string>[]
            {
                (r, value) => r.OmItemNumber = int.Parse(value),
                (r, value) => r.LinkType = value,
                (r, value) => r.ShortDescription = value,
                (r, value) => r.PimsLink = value
            };
        }
    }
}