using Domain.Entities;

namespace CSV
{
    public class OmItemHeaderCsvFormatter : DocumentFormatterBase<OmItemHeader>
    {
        public OmItemHeaderCsvFormatter() : base(",")
        {
            Columns = new[]
            {
                new ColumnFormatter<OmItemHeader>("OmItemName", r => r.OmItemName),
                new ColumnFormatter<OmItemHeader>("OmItemAlias", r => r.OmItemAlias),
                new ColumnFormatter<OmItemHeader>("OmItemId", r => r.OmItemId),
                new ColumnFormatter<OmItemHeader>("OfferingManager", r => r.OfferingManager),
                new ColumnFormatter<OmItemHeader>("PortfolioUnit", r => r.PortfolioUnit),
                new ColumnFormatter<OmItemHeader>("PimsId", r => r.PimsId),
                new ColumnFormatter<OmItemHeader>("OfferingName", r => r.OfferingName),
                new ColumnFormatter<OmItemHeader>("OfferingModule", r => r.OfferingModule),
                new ColumnFormatter<OmItemHeader>("ActiveStatus", r => r.ActiveStatus),
                new ColumnFormatter<OmItemHeader>("OlmCurrentPhase", r => r.OlmCurrentPhase),
                new ColumnFormatter<OmItemHeader>("ConfidentialityClass", r => r.ConfidentialityClass),
                new ColumnFormatter<OmItemHeader>("OfferingType", r => r.OfferingType),
                new ColumnFormatter<OmItemHeader>("CurrentStart", r => r.CurrentStart),
                new ColumnFormatter<OmItemHeader>("CurrentEnd", r => r.CurrentEnd),
                new ColumnFormatter<OmItemHeader>("OfferingCluster", r => r.OfferingCluster),
                new ColumnFormatter<OmItemHeader>("ShortDescription", r => r.ShortDescription),
                new ColumnFormatter<OmItemHeader>("LongDescription", r => r.LongDescription),
            };
        }
    }
}