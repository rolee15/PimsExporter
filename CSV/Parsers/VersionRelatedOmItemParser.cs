using Domain.Entities;
using System;

namespace CSV.Parsers
{
    internal class VersionRelatedOmItemParser : CsvParser<VersionRelatedOmItem>
    {
        public VersionRelatedOmItemParser()
        {
            Parsers = new Action<VersionRelatedOmItem, string>[]
            {
                (r, value) => r.OmItemNumber = int.Parse(value),
                (r, value) => r.VersionNumber = int.Parse(value),
                (r, value) => r.LinkType = value,
                (r, value) => r.ShortDescription = value,
                (r, value) => r.PimsLink = value
            };
        }
    }
}