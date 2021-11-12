using System;

namespace Domain.Entities
{
    public class VersionHeader
    {
        public string VersionName { get; set; }
        public string VersionAlias { get; set; }
        public string FullVersionId { get; set; }
        public User VersionManager { get; set; }
        public string CurrentOlmPhase { get; set; }
        public string PimsId { get; set; }
        public string ArticleNumber { get; set; }
        public string VersionStatus { get; set; }
        public bool ActiveStatus { get; set; }
        public bool AllowUsageInTsiForce { get; set; }
        public string OfferingType { get; set; }
        public string PuReleaseAssignment { get; set; }
        public string TsiPortfolioVersion { get; set; }
        public string BssReleaseAssignment { get; set; }
        public string OssReleaseAssignment { get; set; }
        public DateTime? RequestedOnboarding { get; set; }
        public DateTime? OnboardingDueDate { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Comment { get; set; }
        public string FocusOfMeasure { get; set; }
        public string PrimaryFunding { get; set; }
        public string SecondaryFunding { get; set; }
        public string InnovationTopic { get; set; }
        public string InIpf { get; set; }
        public string InPib { get; set; }
        public string InnovationStructure { get; set; }
        public string InnovationCategory { get; set; }
        public string InternationalRelevance { get; set; }
        public string SupportedMarketingUmbrellaMeasure { get; set; }
        public string MeasurePriority { get; set; }
        public string MeasureStatus { get; set; }
        public string ShortCustomerSalesBenefit { get; set; }
        public string LongCustomerSalesBenefit { get; set; }
        public string TargetAudience { get; set; }
        public string RiskAndMitigation { get; set; }

        public int OmItemNumber { get; set; }
        public int VersionNumber { get; set; }
    }
}