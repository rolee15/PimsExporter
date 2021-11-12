using System.Globalization;
using Domain.Entities;

namespace CSV.Formatters
{
    internal class OlmPhaseCsvFormatter : DocumentFormatterBase<OlmPhase>
    {
        public OlmPhaseCsvFormatter() : base(CultureInfo.CurrentCulture.TextInfo.ListSeparator)
        {
            Columns = new[]
            {
                new ColumnFormatter<OlmPhase>("OmItemNumber", r => r.OmItemNumber),
                new ColumnFormatter<OlmPhase>("OlmPhaseName", r => r.OlmPhaseName),
                new ColumnFormatter<OlmPhase>("CurrentPhase", r => r.CurrentPhase),
                new ColumnFormatter<OlmPhase>("PhaseStartApprovalDate", r => r.PhaseStartApprovalDate),
                new ColumnFormatter<OlmPhase>("PhaseStartDate", r => r.PhaseStartDate),
                new ColumnFormatter<OlmPhase>("PhasePlannedEndDate", r => r.PhasePlannedEndDate),
                new ColumnFormatter<OlmPhase>("PhaseDuration", r => r.PhaseDuration),
                new ColumnFormatter<OlmPhase>("ShortDescription", r => r.ShortDescription),
                new ColumnFormatter<OlmPhase>("LongDescription", r => r.LongDescription)
            };
        }
    }
}