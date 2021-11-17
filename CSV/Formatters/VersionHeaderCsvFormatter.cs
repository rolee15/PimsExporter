using System.Globalization;
using Domain.Entities;

namespace CSV.Formatters
{
    public class VersionHeaderCsvFormatter : DocumentFormatterBase<VersionHeader>
    {
        public VersionHeaderCsvFormatter() : base(CultureInfo.CurrentCulture.TextInfo.ListSeparator)
        {
            Columns = new[]
            {
                new ColumnFormatter<VersionHeader>("OmItemNumber", r => r.OmItemNumber),
                new ColumnFormatter<VersionHeader>("VersionNumber", r => r.VersionNumber),
                new ColumnFormatter<VersionHeader>("VersionName", r => r.VersionName),
                new ColumnFormatter<VersionHeader>("VersionAlias", r => r.VersionAlias),
                new ColumnFormatter<VersionHeader>("FullVersionId", r => r.FullVersionId),
                new ColumnFormatter<VersionHeader>("VersionManager", r => r.VersionManager),
                new ColumnFormatter<VersionHeader>("CurrentOlmPhase", r => r.CurrentOlmPhase),
                new ColumnFormatter<VersionHeader>("PimsId", r => r.PimsId),
                new ColumnFormatter<VersionHeader>("ArticleNumber", r => r.ArticleNumber),
                new ColumnFormatter<VersionHeader>("VersionStatus", r => r.VersionStatus),
                new ColumnFormatter<VersionHeader>("ActiveStatus", r => r.ActiveStatus),
                new ColumnFormatter<VersionHeader>("AllowUsageInTsiForce", r => r.AllowUsageInTsiForce),
                new ColumnFormatter<VersionHeader>("OfferingType", r => r.OfferingType),
                new ColumnFormatter<VersionHeader>("PuReleaseAssignment", r => r.PuReleaseAssignment),
                new ColumnFormatter<VersionHeader>("TsiPortfolioVersion", r => r.TsiPortfolioVersion),
                new ColumnFormatter<VersionHeader>("BssReleaseAssignment", r => r.BssReleaseAssignment),
                new ColumnFormatter<VersionHeader>("OssReleaseAssignment", r => r.OssReleaseAssignment),
                new ColumnFormatter<VersionHeader>("RequestedOnboarding", r => r.RequestedOnboarding),
                new ColumnFormatter<VersionHeader>("OnboardingDueDate", r => r.OnboardingDueDate),
                new ColumnFormatter<VersionHeader>("ShortDescription", r => r.ShortDescription),
                new ColumnFormatter<VersionHeader>("LongDescription", r => r.LongDescription),
                new ColumnFormatter<VersionHeader>("Comment", r => r.Comment),
                new ColumnFormatter<VersionHeader>("FocusOfMeasure", r => r.FocusOfMeasure),
                new ColumnFormatter<VersionHeader>("PrimaryFunding", r => r.PrimaryFunding),
                new ColumnFormatter<VersionHeader>("SecondaryFunding", r => r.SecondaryFunding),
                new ColumnFormatter<VersionHeader>("InnovationTopic", r => r.InnovationTopic),
                new ColumnFormatter<VersionHeader>("InIpf", r => r.InIpf),
                new ColumnFormatter<VersionHeader>("InPib", r => r.InPib),
                new ColumnFormatter<VersionHeader>("InnovationStructure", r => r.InnovationStructure),
                new ColumnFormatter<VersionHeader>("InnovationCategory", r => r.InnovationCategory),
                new ColumnFormatter<VersionHeader>("InternationalRelevance", r => r.InternationalRelevance),
                new ColumnFormatter<VersionHeader>("SupportedMarketingUmbrellaMeasure",
                    r => r.SupportedMarketingUmbrellaMeasure),
                new ColumnFormatter<VersionHeader>("MeasurePriority", r => r.MeasurePriority),
                new ColumnFormatter<VersionHeader>("MeasureStatus", r => r.MeasureStatus),
                new ColumnFormatter<VersionHeader>("ShortCustomerSalesBenefit", r => r.ShortCustomerSalesBenefit),
                new ColumnFormatter<VersionHeader>("LongCustomerSalesBenefit", r => r.LongCustomerSalesBenefit),
                new ColumnFormatter<VersionHeader>("TargetAudience", r => r.TargetAudience),
                new ColumnFormatter<VersionHeader>("RiskAndMitigation", r => r.RiskAndMitigation)
            };
        }
    }
}