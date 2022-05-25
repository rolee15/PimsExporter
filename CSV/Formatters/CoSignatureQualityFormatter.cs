using System.Globalization;
using Domain.Entities;

namespace CSV.Formatters
{
    internal class CoSignatureQualityFormatter : DocumentFormatterBase<CoSignatureQuality>
    {
        public CoSignatureQualityFormatter() : base(CultureInfo.CurrentCulture.TextInfo.ListSeparator)
        {
            Columns = new[]
            {
                new ColumnFormatter<CoSignatureQuality>("OmItemNumber", r => r.OmItemNumber),
                new ColumnFormatter<CoSignatureQuality>("VersionNumber", r => r.VersionNumber),
                new ColumnFormatter<CoSignatureQuality>("CoSignatureId", r => r.CoSignatureId),
                new ColumnFormatter<CoSignatureQuality>("LastCheckTime", r => r.LastCheckTime),
                new ColumnFormatter<CoSignatureQuality>("Type", r => r.Type),
                new ColumnFormatter<CoSignatureQuality>("MandatoryDocumentOrRole", r => r.MandatoryDocumentOrRole),
                new ColumnFormatter<CoSignatureQuality>("ResultStatus", r => r.ResultStatus),
                new ColumnFormatter<CoSignatureQuality>("Result", r => r.Result),
                new ColumnFormatter<CoSignatureQuality>("IsOptOut", r => r.IsOptOut),
                new ColumnFormatter<CoSignatureQuality>("OptOutRemark", r => r.OptOutRemark)
            };
        }
    }
}