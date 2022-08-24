using Domain.Entities;
using System;

namespace CSV.Parsers
{
    internal class CoSignatureHeaderParser : CsvParser<CoSignatureHeader>
    {
        public CoSignatureHeaderParser()
        {
            Parsers = new Action<CoSignatureHeader, string>[]
            {
                (r, value) => r.OmItemNumber = int.Parse(value),
                (r, value) => r.VersionNumber = int.Parse(value),
                (r, value) => r.CoSignatureId = int.Parse(value),
                (r, value) => r.Topic = value,
                (r, value) => r.OmItemName = value,
                (r, value) => r.Requestor = ParseUser(value),
                (r, value) => r.PortfolioUnit = value,
                (r, value) => r.OmItemVersion = value,
                (r, value) => r.ConfidentialityClass = value,
                (r, value) => r.OlmPhase = value,
                (r, value) => r.OlmMilestone = value,
                (r, value) => r.CoSignatureDate = ParseNullableDate(value),
                (r, value) => r.CoSignatureDueDate = ParseNullableDate(value),
                (r, value) => r.Status = value,
                (r, value) => r.Result = value,
                (r, value) => r.Remark = value,
                (r, value) => r.CoSignatureSubmittedDate = ParseNullableDate(value),
                (r, value) => r.CoSignatureResultDate = ParseNullableDate(value),
                (r, value) => r.QualityIndex = ParseDouble(value),
                (r, value) => r.QualityIndexUpdated = ParseNullableDate(value)
            };
        }
    }
}