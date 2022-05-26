using System.Globalization;
using Domain.Entities;

namespace CSV.Formatters
{
    internal class VersionBudgetCsvFormatter : DocumentFormatterBase<VersionBudget>
    {
        public VersionBudgetCsvFormatter() : base(CultureInfo.CurrentCulture.TextInfo.ListSeparator)
        {
            Columns = new[]
            {
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.OmItemNumber), r => r.OmItemNumber),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.VersionNumber), r => r.VersionNumber),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.Year), r => r.Year),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.DeltaRevenuePlan), r => r.DeltaRevenuePlan),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.DeltaOePlan), r => r.DeltaOePlan),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.BssBudgetOpexPlan), r => r.BssBudgetOpexPlan),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.BssBudgetCapexPlan), r => r.BssBudgetCapexPlan),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.BssBudgetOpexApproved),
                    r => r.BssBudgetOpexApproved),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.BssBudgetCapexApproved),
                    r => r.BssBudgetCapexApproved),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.OssBudgetOpexPlan), r => r.OssBudgetOpexPlan),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.OssBudgetCapexPlan), r => r.OssBudgetCapexPlan),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.OssBudgetOpexApproved),
                    r => r.OssBudgetOpexApproved),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.OssBudgetCapexApproved),
                    r => r.OssBudgetCapexApproved),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.OtherBudgetOpexPlan),
                    r => r.OtherBudgetOpexPlan),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.OtherBudgetCapexPlan),
                    r => r.OtherBudgetCapexPlan),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.OtherBudgetOpexApproved),
                    r => r.OtherBudgetOpexApproved),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.OtherBudgetCapexApproved),
                    r => r.OtherBudgetCapexApproved),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.RnDBudgetOpexPlan), r => r.RnDBudgetOpexPlan),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.RnDBudgetCapexPlan), r => r.RnDBudgetCapexPlan),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.RnDBudgetOpexApproved),
                    r => r.RnDBudgetOpexApproved),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.RnDBudgetCapexApproved),
                    r => r.RnDBudgetCapexApproved),
                new ColumnFormatter<VersionBudget>(nameof(VersionBudget.Comment),
                    r => r.Comment)
            };
        }
    }
}