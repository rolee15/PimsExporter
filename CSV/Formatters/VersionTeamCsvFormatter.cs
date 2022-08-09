using System.Globalization;
using Domain.Entities;

namespace CSV.Formatters
{
    internal class VersionTeamCsvFormatter : DocumentFormatterBase<VersionTeam>
    {
        public VersionTeamCsvFormatter() : base(CultureInfo.CurrentCulture.TextInfo.ListSeparator)
        {
            Columns = new[]
            {
                new ColumnFormatter<VersionTeam>(nameof(VersionTeam.OmItemNumber), r => r.OmItemNumber),
                new ColumnFormatter<VersionTeam>(nameof(VersionTeam.VersionNumber), r => r.VersionNumber),
                new ColumnFormatter<VersionTeam>(nameof(VersionTeam.Member), r => r.Member?.Name),
                new ColumnFormatter<VersionTeam>("MemberEmail", r => r.Member?.Email),
                new ColumnFormatter<VersionTeam>(nameof(VersionTeam.TeamRole), r => r.TeamRole),
                new ColumnFormatter<VersionTeam>(nameof(VersionTeam.RoleComment), r => r.RoleComment),
                new ColumnFormatter<VersionTeam>(nameof(VersionTeam.ValidFrom), r => r.ValidFrom),
                new ColumnFormatter<VersionTeam>(nameof(VersionTeam.ValidTo), r => r.ValidTo),
                new ColumnFormatter<VersionTeam>(nameof(VersionTeam.DeputyOf), r => r.DeputyOf),
                new ColumnFormatter<VersionTeam>(nameof(VersionTeam.CoSigner), r => r.CoSigner)
            };
        }
    }
}