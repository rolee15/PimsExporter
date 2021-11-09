using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV.Formatters
{
    internal class VersionBudgetCsvFormatter : DocumentFormatterBase<VersionBudget>
    {
        public VersionBudgetCsvFormatter() : base(CultureInfo.CurrentCulture.TextInfo.ListSeparator)
        {
            Columns = new[]
            {
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.Year), r => r.Year),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.DeltaRevenuePlan), r => r.DeltaRevenuePlan),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.DeltaOEPlan), r => r.DeltaOEPlan),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.BSSBudgetOpexPlan), r => r.BSSBudgetOpexPlan),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.BSSBudgetCapexPlan), r => r.BSSBudgetCapexPlan),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.BSSBudgetOpexApproved), r => r.BSSBudgetOpexApproved),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.BSSBudgetCapexApproved), r => r.BSSBudgetCapexApproved),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.OSSBudgetOpexPlan), r => r.OSSBudgetOpexPlan),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.OSSBudgetCapexPlan), r => r.OSSBudgetCapexPlan),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.OSSBudgetOpexApproved), r => r.OSSBudgetOpexApproved),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.OSSBudgetCapexApproved), r => r.OSSBudgetCapexApproved),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.OtherBudgetOpexPlan), r => r.OtherBudgetOpexPlan),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.OtherBudgetCapexPlan), r => r.OtherBudgetCapexPlan),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.OtherBudgetOpexApproved), r => r.OtherBudgetOpexApproved),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.OtherBudgetCapexApproved), r => r.OtherBudgetCapexApproved),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.RnDBudgetOpexPlan), r => r.RnDBudgetOpexPlan),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.RnDBudgetCapexPlan), r => r.RnDBudgetCapexPlan),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.RnDBudgetOpexApproved), r => r.RnDBudgetOpexApproved),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.RnDBudgetCapexApproved), r => r.RnDBudgetCapexApproved),
            };
        }
    }
}
