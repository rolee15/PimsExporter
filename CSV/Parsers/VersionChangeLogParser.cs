using Domain.Entities;
using System;

namespace CSV.Parsers
{
    internal class VersionChangeLogParser : CsvParser<VersionChangeLog>
    {
        public VersionChangeLogParser()
        {
            Parsers = new Action<VersionChangeLog, string>[]
            {
                (r, value) => r.OmItemNumber = int.Parse(value),
                (r, value) => r.VersionNumber = int.Parse(value),
                (r, value) => r.Event = value,
                (r, value) => r.DateAndTimeOfChange = ParseNullableDate(value),
                (r, value) => r.User = ParseUser(value),
                (r, value) => r.TypeOfChange = value,
                (r, value) => r.ChangeSection = value
            };
        }
    }
}