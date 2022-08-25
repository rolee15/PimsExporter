using System.Globalization;
using Domain.Entities;

namespace CSV.Formatters
{
    internal class TeamCsvFormatter : DocumentFormatterBase<Team>
    {
        public TeamCsvFormatter() : base(CultureInfo.CurrentCulture.TextInfo.ListSeparator)
        {
            Columns = new[]
            {
                new ColumnFormatter<Team>("OmItemNumber", r => r.OmItemNumber),
                new ColumnFormatter<Team>("Member", r => FormatUser(r.Member)),
                new ColumnFormatter<Team>("TeamRole", r => r.TeamRole),
                new ColumnFormatter<Team>("RoleComment", r => r.RoleComment),
                new ColumnFormatter<Team>("ValidFrom", r => r.ValidFrom),
                new ColumnFormatter<Team>("ValidTo", r => r.ValidTo),
                new ColumnFormatter<Team>("DeputyOf", r => FormatUser(r.DeputyOf)),
                new ColumnFormatter<Team>("CoSigner", r => r.CoSigner)
            };
        }
    }
}