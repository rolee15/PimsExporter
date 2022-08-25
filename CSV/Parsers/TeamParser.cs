using Domain.Entities;
using System;

namespace CSV.Parsers
{
    internal class TeamParser : CsvParser<Team>
    {
        public TeamParser()
        {
            Parsers = new Action<Team, string>[]
            {
                (r, value) => r.OmItemNumber = int.Parse(value),
                (r, value) => r.Member = ParseUser(value),
                (r, value) => r.TeamRole = value,
                (r, value) => r.RoleComment = value,
                (r, value) => r.ValidFrom = ParseNullableDate(value),
                (r, value) => r.ValidTo = ParseNullableDate(value),
                (r, value) => r.DeputyOf = ParseUser(value),
                (r, value) => r.CoSigner = ParseBool(value)
            };
        }
    }
}