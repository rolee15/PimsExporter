using System.Globalization;
using Domain.Entities;

namespace CSV
{
    public class OmItemMilestonesCsvFormatter : DocumentFormatterBase<OmItemMilestone>
    {
        public OmItemMilestonesCsvFormatter() : base(";")
        {
            Columns = new[]
            {
                new ColumnFormatter<OmItemMilestone>("MilestoneName", r => r.MilestoneName),
                new ColumnFormatter<OmItemMilestone>("DateBasicPlan", r => r.DateBasicPlan),
                new ColumnFormatter<OmItemMilestone>("DatePlan", r => r.DatePlan),
                new ColumnFormatter<OmItemMilestone>("DateActual", r => r.DateActual),
                new ColumnFormatter<OmItemMilestone>("MilestoneType", r => r.MilestoneType),
                new ColumnFormatter<OmItemMilestone>("OLMPhase", r => r.OLMPhase),
                new ColumnFormatter<OmItemMilestone>("Default", r => r.Default),
                new ColumnFormatter<OmItemMilestone>("ShortDescription", r => r.ShortDescription),
                new ColumnFormatter<OmItemMilestone>("LongDescription", r => r.LongDescription)
            };
        }
    }
}
