using Domain.Entities;

namespace CSV
{
    public class AllOmItemCsvFormatter : DocumentFormatterBase<AllOmItem>
    {
        public AllOmItemCsvFormatter() : base(",")
        {
            Columns = new[]
            {
                new ColumnFormatter<AllOmItem>("PortfolioUnit", r => r.PortfolioUnit),
                new ColumnFormatter<AllOmItem>("OfferingName", r => r.OfferingName),
                new ColumnFormatter<AllOmItem>("OfferingModule", r => r.OfferingModule),
                new ColumnFormatter<AllOmItem>("OfferingModuleId", r => r.OfferingModuleId),
                new ColumnFormatter<AllOmItem>("PimsId", r => r.PimsId),
                new ColumnFormatter<AllOmItem>("OmItemName", r => r.OmItemName),
                new ColumnFormatter<AllOmItem>("OfferingType", r => r.OfferingType),
                new ColumnFormatter<AllOmItem>("OfferingManager", r => r.OfferingManager),
                new ColumnFormatter<AllOmItem>("OmItemAlias", r => r.OmItemAlias),
                new ColumnFormatter<AllOmItem>("OmItemId", r => r.OmItemId),
                new ColumnFormatter<AllOmItem>("OlmCurrentPhase", r => r.OlmCurrentPhase),
                new ColumnFormatter<AllOmItem>("OlmPhaseStart", r => r.OlmPhaseStart),
                new ColumnFormatter<AllOmItem>("OlmPhaseEnd", r => r.OlmPhaseEnd),
            };
        }
    }
}