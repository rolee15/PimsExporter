using Domain.Entities;
using System;

namespace CSV.Parsers
{
    public class OmItemHeaderParser : CsvParser<OmItemHeader>
    {
        internal OmItemHeaderParser()
        {
            Parsers = new Action<OmItemHeader, string>[]
            {
                (r, value) => r.OmItemNumber = int.Parse(value),
                (r, value) => r.OmItemName = value,
                (r, value) => r.OmItemAlias = value,
                (r, value) => r.OmItemId = value,
                (r, value) => r.OfferingManager = ParseUser(value),
                (r, value) => r.PortfolioUnit = value,
                (r, value) => r.PortfolioUnitSapId = value,
                (r, value) => r.OfferingModuleId = value,
                (r, value) => r.PimsId = value,
                (r, value) => r.OfferingName = value,
                (r, value) => r.OfferingNameSapId = value,
                (r, value) => r.OfferingModule = value,
                (r, value) => r.OfferingModuleSapId = value,
                (r, value) => r.ActiveStatus = value,
                (r, value) => r.OlmCurrentPhase = value,
                (r, value) => r.ConfidentialityClass = value,
                (r, value) => r.OfferingType = value,
                (r, value) => r.CurrentStart = ParseNullableDate(value),
                (r, value) => r.CurrentEnd = ParseNullableDate(value),
                (r, value) => r.OfferingCluster = value,
                (r, value) => r.OfferingClusterSapId = value,
                (r, value) => r.ShortDescription = value,
                (r, value) => r.LongDescription = value

            };
        }
    }
}
