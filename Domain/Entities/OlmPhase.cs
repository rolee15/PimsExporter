using System;

namespace Domain.Entities
{
    public class OlmPhase
    {
        public string OlmPhaseName { get; set; }
        public string CurrentPhase { get; set; }
        public string PhaseStartApprovalDate { get; set; }
        public DateTime? PhaseStartDate { get; set; }
        public DateTime? PhasePlannedEndDate { get; set; }
        public string PhaseDuration { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        public int OmItemNumber { get; set; }
    }
}
