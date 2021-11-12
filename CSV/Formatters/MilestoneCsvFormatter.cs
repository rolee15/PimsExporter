﻿using System.Globalization;
using Domain.Entities;

namespace CSV.Formatters
{
    public class MilestoneCsvFormatter : DocumentFormatterBase<Milestone>
    {
        public MilestoneCsvFormatter() : base(CultureInfo.CurrentCulture.TextInfo.ListSeparator)
        {
            Columns = new[]
            {
                new ColumnFormatter<Milestone>("OmItemNumber", r => r.OmItemNumber),
                new ColumnFormatter<Milestone>("MilestoneName", r => r.MilestoneName),
                new ColumnFormatter<Milestone>("DateBasicPlan", r => r.DateBasicPlan),
                new ColumnFormatter<Milestone>("DatePlan", r => r.DatePlan),
                new ColumnFormatter<Milestone>("DateActual", r => r.DateActual),
                new ColumnFormatter<Milestone>("MilestoneType", r => r.MilestoneType),
                new ColumnFormatter<Milestone>("OLMPhase", r => r.OLMPhase),
                new ColumnFormatter<Milestone>("Default", r => r.Default),
                new ColumnFormatter<Milestone>("ShortDescription", r => r.ShortDescription),
                new ColumnFormatter<Milestone>("LongDescription", r => r.LongDescription)
            };
        }
    }
}