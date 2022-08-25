using Domain.Entities;
using System;

namespace CSV.Parsers
{
    internal class VersionMilestoneParser : CsvParser<Milestone>
    {
        public VersionMilestoneParser()
        {
            Parsers = new Action<Milestone, string>[]
            {
                (r, value) => r.OmItemNumber = int.Parse(value),
                (r, value) => r.VersionNumber = int.Parse(value),
                (r, value) => r.MilestoneName = value,
                (r, value) => r.DateBasicPlan = ParseNullableDate(value),
                (r, value) => r.DatePlan = ParseNullableDate(value),
                (r, value) => r.DateActual = ParseNullableDate(value),
                (r, value) => r.MilestoneType = value,
                (r, value) => r.OlmPhase = value,
                (r, value) => r.Default = value,
                (r, value) => r.ShortDescription = value,
                (r, value) => r.LongDescription = value
            };
        }
    }
}