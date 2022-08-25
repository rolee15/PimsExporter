using Domain.Entities;
using System;

namespace CSV.Parsers
{
    public class VersionHeaderParser : CsvParser<VersionHeader>
    {
        public VersionHeaderParser()
        {
            Parsers = new Action<VersionHeader, string>[]
            {
                (r, value) => r.OmItemNumber = int.Parse(value),
                (r, value) => r.VersionNumber = int.Parse(value),
                (r, value) => r.VersionName = value,
                (r, value) => r.VersionAlias = value,
                (r, value) => r.FullVersionId = value,
                (r, value) => r.VersionManager = ParseUser(value),
                (r, value) => r.CurrentOlmPhase = value,
                (r, value) => r.PimsId = value,
                (r, value) => r.ArticleNumber = value,
                (r, value) => r.VersionStatus = value,
                (r, value) => r.ActiveStatus = ParseBool(value),
                (r, value) => r.AllowUsageInTsiForce = ParseBool(value),
                (r, value) => r.OfferingType = value,
                (r, value) => r.PuReleaseAssignment = value,
                (r, value) => r.TsiPortfolioVersion = value,
                (r, value) => r.BssReleaseAssignment = value,
                (r, value) => r.OssReleaseAssignment = value,
                (r, value) => r.RequestedOnboarding = ParseNullableDate(value),
                (r, value) => r.OnboardingDueDate = ParseNullableDate(value),
                (r, value) => r.ShortDescription = value,
                (r, value) => r.LongDescription = value,
                (r, value) => r.Comment = value,
                (r, value) => r.FocusOfMeasure = value,
                (r, value) => r.PrimaryFunding = value,
                (r, value) => r.SecondaryFunding = value,
                (r, value) => r.InnovationTopic = value,
                (r, value) => r.InIpf = value,
                (r, value) => r.InPib = value,
                (r, value) => r.InnovationStructure = value,
                (r, value) => r.InnovationCategory = value,
                (r, value) => r.InternationalRelevance = value,
                (r, value) => r.SupportedMarketingUmbrellaMeasure = value,
                (r, value) => r.MeasurePriority = value,
                (r, value) => r.MeasureStatus = value,
                (r, value) => r.ShortCustomerSalesBenefit = value,
                (r, value) => r.LongCustomerSalesBenefit = value,
                (r, value) => r.TargetAudience = value,
                (r, value) => r.RiskAndMitigation = value
            };
        }
    }
}
