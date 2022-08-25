using Domain.Entities;
using System;

namespace CSV.Parsers
{
    internal class CoSignatureQualityParser : CsvParser<CoSignatureQuality>
    {
        public CoSignatureQualityParser()
        {
            Parsers = new Action<CoSignatureQuality, string>[]
            {
                (r, value) => r.OmItemNumber = int.Parse(value),
                (r, value) => r.VersionNumber = int.Parse(value),
                (r, value) => r.CoSignatureId = int.Parse(value),
                (r, value) => r.LastCheckTime = ParseNullableDate(value),
                (r, value) => r.Type = value,
                (r, value) => r.MandatoryDocumentOrRole = value,
                (r, value) => r.ResultStatus = ParseBool(value),
                (r, value) => r.Result = value,
                (r, value) => r.IsOptOut = ParseBool(value),
                (r, value) => r.OptOutRemark = value
            };
        }
    }
}