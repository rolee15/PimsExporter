using System;

namespace Domain.Entities
{
    public class Milestone
    {
        public string MilestoneName { get; set; }
        public DateTime? DateBasicPlan { get; set; }
        public DateTime? DatePlan { get; set; }
        public DateTime? DateActual { get; set; }
        public string MilestoneType { get; set; }
        public string OLMPhase { get; set; }
        public string Default { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int OmItemNumber { get; set; }
    }
}
