using System.Globalization;
using Domain.Entities;

namespace CSV.Formatters
{
    internal class CoSignatureHeaderFormatter : DocumentFormatterBase<CoSignatureHeader>
    {
        public CoSignatureHeaderFormatter() : base(CultureInfo.CurrentCulture.TextInfo.ListSeparator)
        {
            Columns = new[]
            {
                new ColumnFormatter<CoSignatureHeader>("OmItemNumber", r => r.OmItemNumber),
                new ColumnFormatter<CoSignatureHeader>("VersionNumber", r => r.VersionNumber),
                new ColumnFormatter<CoSignatureHeader>("CoSignatureId", r => r.CoSignatureId),
                new ColumnFormatter<CoSignatureHeader>("Topic", r => r.Topic),
                new ColumnFormatter<CoSignatureHeader>("OmItemName", r => r.OmItemName),
                new ColumnFormatter<CoSignatureHeader>("Requestor", r => r.Requestor),
                new ColumnFormatter<CoSignatureHeader>("PortfolioUnit", r => r.PortfolioUnit),
                new ColumnFormatter<CoSignatureHeader>("OmItemVersion", r => r.OmItemVersion),
                new ColumnFormatter<CoSignatureHeader>("OfferingCluster", r => r.OfferingCluster),
                new ColumnFormatter<CoSignatureHeader>("ConfidentialityClass", r => r.ConfidentialityClass),
                new ColumnFormatter<CoSignatureHeader>("OlmPhase", r => r.OlmPhase),
                new ColumnFormatter<CoSignatureHeader>("OlmMilestone", r => r.OlmMilestone),
                new ColumnFormatter<CoSignatureHeader>("CoSignatureDate", r => r.CoSignatureDate),
                new ColumnFormatter<CoSignatureHeader>("CoSignatureDueDate", r => r.CoSignatureDueDate),
                new ColumnFormatter<CoSignatureHeader>("Status", r => r.Status),
                new ColumnFormatter<CoSignatureHeader>("Result", r => r.Result),
                new ColumnFormatter<CoSignatureHeader>("Remark", r => r.Remark),
                new ColumnFormatter<CoSignatureHeader>("CoSignatureSubmittedDate", r => r.CoSignatureSubmittedDate),
                new ColumnFormatter<CoSignatureHeader>("CoSignatureResultDate", r => r.CoSignatureResultDate),
                new ColumnFormatter<CoSignatureHeader>("QualityIndex", r => r.QualityIndex),
                new ColumnFormatter<CoSignatureHeader>("QualityIndexUpdated", r => r.QualityIndexUpdated)
            };
        }
    }
}