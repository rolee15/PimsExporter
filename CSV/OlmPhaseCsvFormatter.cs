using Domain.Entities;
using System.Globalization;

namespace CSV
{
    internal class OlmPhaseCsvFormatter : DocumentFormatterBase<OlmPhase>
    {
        public OlmPhaseCsvFormatter() : base(CultureInfo.CurrentCulture.TextInfo.ListSeparator)
        {
            Columns = new[]
            {
                new ColumnFormatter<OlmPhase>("OlmPhaseName", o => o.OlmPhaseName),
                new ColumnFormatter<OlmPhase>("CurrentPhase", o => o.CurrentPhase),
                new ColumnFormatter<OlmPhase>("PhaseStartApprovalDate", o => o.PhaseStartApprovalDate),
                new ColumnFormatter<OlmPhase>("PhaseStartDate", o => o.PhaseStartDate),
                new ColumnFormatter<OlmPhase>("PhasePlannedEndDate", o => o.PhasePlannedEndDate),
                new ColumnFormatter<OlmPhase>("PhaseDuration", o => o.PhaseDuration),
                new ColumnFormatter<OlmPhase>("ShortDescription", o => o.ShortDescription),
                new ColumnFormatter<OlmPhase>("LongDescription", o => o.LongDescription),
                new ColumnFormatter<OlmPhase>("OmItemNumber", o => o.OmItemNumber)
            };
        }
    }
}