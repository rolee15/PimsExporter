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
                new ColumnFormatter<CoSignatureCoSigner>("OmItemNumber", r => r.OmItemNumber),
                new ColumnFormatter<CoSignatureCoSigner>("VersionNumber", r => r.VersionNumber),
                new ColumnFormatter<CoSignatureCoSigner>("CoSignatureId", r => r.CoSignatureId),
                new ColumnFormatter<CoSignatureCoSigner>("Member", r => r.Member),
                new ColumnFormatter<CoSignatureCoSigner>("CoSignDeputy", r => r.Deputy),
                new ColumnFormatter<CoSignatureCoSigner>("TeamRole", r => r.TeamRole),
                new ColumnFormatter<CoSignatureCoSigner>("RoleComment", r => r.RoleComment),
                new ColumnFormatter<CoSignatureCoSigner>("CoSignerDate", r => r.CoSignerDate),
                new ColumnFormatter<CoSignatureCoSigner>("CoSignerResult", r => r.CoSignerResult),
                new ColumnFormatter<CoSignatureCoSigner>("CoSignedBy", r => r.CoSignedBy),
                new ColumnFormatter<CoSignatureCoSigner>("Remark", r => r.Remark)
            };
        }
    }
}