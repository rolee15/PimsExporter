using System;

namespace Domain.Entities
{
    public class OmItemHeader
    {
        public string OmItemName { get; set; }
        public string OmItemAlias {  get; set; }
        public string OmItemId {  get; set; }
        public User OfferingManager { get; set; }
        public string PortfolioUnit { get; set; }
        public string PimsId { get; set; }
        public string OfferingName { get; set; }
        public string OfferingModule { get; set; }
        public string ActiveStatus { get; set; }
        public string OlmCurrentPhase { get; set; }
        public string ConfidentialityClass { get; set; }
        public string OfferingType { get; set; }
        public DateTime? CurrentStart { get; set; }
        public DateTime? CurrentEnd { get; set; }
        public string OfferingCluster { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int OmItemNumber { get; set; }
    }
}