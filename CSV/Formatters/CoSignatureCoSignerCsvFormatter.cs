using System.Globalization;
using Domain.Entities;

namespace CSV.Formatters
{
    internal class CoSignatureCoSignerFormatter : DocumentFormatterBase<CoSignatureCoSigner>
    {
        public CoSignatureCoSignerFormatter() : base(CultureInfo.CurrentCulture.TextInfo.ListSeparator)
        {
            Columns = new[]
            {
                new ColumnFormatter<CoSignatureCoSigner>(nameof(CoSignatureCoSigner.OmItemNumber), r => r.OmItemNumber),
                new ColumnFormatter<CoSignatureCoSigner>(nameof(CoSignatureCoSigner.VersionNumber), r => r.VersionNumber),
                new ColumnFormatter<CoSignatureCoSigner>(nameof(CoSignatureCoSigner.CoSignatureId), r => r.CoSignatureId),
                new ColumnFormatter<CoSignatureCoSigner>(nameof(CoSignatureCoSigner.Member), r => r.Member?.Name),
                new ColumnFormatter<CoSignatureCoSigner>("MemberEmail", r => r.Member?.Email),
                new ColumnFormatter<CoSignatureCoSigner>("CoSignDeputy", r => r.Deputy),
                new ColumnFormatter<CoSignatureCoSigner>(nameof(CoSignatureCoSigner.TeamRole), r => r.TeamRole),
                new ColumnFormatter<CoSignatureCoSigner>(nameof(CoSignatureCoSigner.RoleComment), r => r.RoleComment),
                new ColumnFormatter<CoSignatureCoSigner>(nameof(CoSignatureCoSigner.CoSignerDate), r => r.CoSignerDate),
                new ColumnFormatter<CoSignatureCoSigner>(nameof(CoSignatureCoSigner.CoSignerResult), r => r.CoSignerResult),
                new ColumnFormatter<CoSignatureCoSigner>(nameof(CoSignatureCoSigner.CoSignedBy), r => r.CoSignedBy),
                new ColumnFormatter<CoSignatureCoSigner>(nameof(CoSignatureCoSigner.Remark), r => r.Remark)
            };
        }
    }
}