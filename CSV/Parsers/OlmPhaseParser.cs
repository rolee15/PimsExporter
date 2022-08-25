using Domain.Entities;
using System;

namespace CSV.Parsers
{
    internal class OlmPhaseParser : CsvParser<OlmPhase>
    {
        public OlmPhaseParser()
        {
            Parsers = new Action<OlmPhase, string>[]
            {
                (r, value) => r.OmItemNumber = int.Parse(value),
                (r, value) => r.OlmPhaseName = value,
                (r, value) => r.CurrentPhase = value,
                (r, value) => r.PhaseStartApprovalDate = value,
                (r, value) => r.PhaseStartDate = ParseNullableDate(value),
                (r, value) => r.PhasePlannedEndDate = ParseNullableDate(value),
                (r, value) => r.PhaseDuration = value,
                (r, value) => r.ShortDescription = value,
                (r, value) => r.LongDescription = value
            };
        }
    }
}