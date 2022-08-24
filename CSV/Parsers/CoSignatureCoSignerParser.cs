using Domain.Entities;
using System;

namespace CSV.Parsers
{
    internal class CoSignatureCoSignerParser : CsvParser<CoSignatureCoSigner>
    {
        public CoSignatureCoSignerParser()
        {
            Parsers = new Action<CoSignatureCoSigner, string>[]
            {
                (r, value) => r.OmItemNumber = int.Parse(value),
                (r, value) => r.VersionNumber = int.Parse(value),
                (r, value) => r.CoSignatureId = int.Parse(value),
                (r, value) => r.Member = ParseUser(value),
                (r, value) => r.Deputy = ParseUser(value),
                (r, value) => r.TeamRole = value,
                (r, value) => r.RoleComment = value,
                (r, value) => r.CoSignerDate = ParseNullableDate(value),
                (r, value) => r.CoSignerResult = value,
                (r, value) => r.CoSignedBy = ParseUser(value),
                (r, value) => r.Remark = value
            };
        }
    }
}