using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV.Formatters
{
    class CoSignatureQualityFormatter : DocumentFormatterBase<CoSignatureQuality>
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
                new ColumnFormatter<CoSignatureQuality>("OptOutRuleId", r => r.OptOutRuleId),
                new ColumnFormatter<CoSignatureQuality>("OptOutRemark", r => r.OptOutRemark),
            };
        }
    }
}
