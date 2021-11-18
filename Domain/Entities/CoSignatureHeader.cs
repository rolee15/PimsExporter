using System;

namespace Domain.Entities
{
    public class CoSignatureHeader
    {
        public string Topic { get; set; }
        public string OmItemName { get; set; }
        public User Requestor { get; set; }
        public string PortfolioUnit { get; set; }
        public string OmItemVersion { get; set; }
        public string OfferingCluster { get; set; }
        public string ConfidentialityClass { get; set; }
        public string OlmPhase { get; set; }
        public string OlmMilestone { get; set; }
        public DateTime? CoSignatureDate { get; set; }
        public DateTime? CoSignatureDueDate { get; set; }
        public string Status { get; set; }
        public string Result { get; set; }
        public string Remark { get; set; }
        public int OmItemNumber { get; set; }
        public int VersionNumber { get; set; }
        public int CoSignatureId { get; set; }
    }
}