using Domain.Entities;
using System;

namespace CSV.Parsers
{
    internal class VersionBudgetParser : CsvParser<VersionBudget>
    {
        public VersionBudgetParser()
        {
            Parsers = new Action<VersionBudget, string>[]
            {
                (r, value) => r.OmItemNumber = int.Parse(value),
                (r, value) => r.VersionNumber = int.Parse(value),
                (r, value) => r.Year = int.Parse(value),
                (r, value) => r.DeltaRevenuePlan = ParseNullableDouble(value),
                (r, value) => r.DeltaOePlan = ParseNullableDouble(value),
                (r, value) => r.BssBudgetOpexPlan = ParseNullableDouble(value),
                (r, value) => r.BssBudgetCapexPlan = ParseNullableDouble(value),
                (r, value) => r.BssBudgetOpexApproved = ParseNullableDouble(value),
                (r, value) => r.BssBudgetCapexApproved = ParseNullableDouble(value),
                (r, value) => r.OssBudgetOpexPlan = ParseNullableDouble(value),
                (r, value) => r.OssBudgetCapexPlan = ParseNullableDouble(value),
                (r, value) => r.OssBudgetOpexApproved = ParseNullableDouble(value),
                (r, value) => r.OssBudgetCapexApproved = ParseNullableDouble(value),
                (r, value) => r.OtherBudgetOpexPlan = ParseNullableDouble(value),
                (r, value) => r.OtherBudgetCapexPlan = ParseNullableDouble(value),
                (r, value) => r.OtherBudgetOpexApproved = ParseNullableDouble(value),
                (r, value) => r.OtherBudgetCapexApproved = ParseNullableDouble(value),
                (r, value) => r.RnDBudgetOpexPlan = ParseNullableDouble(value),
                (r, value) => r.RnDBudgetCapexPlan = ParseNullableDouble(value),
                (r, value) => r.RnDBudgetOpexApproved = ParseNullableDouble(value),
                (r, value) => r.RnDBudgetCapexApproved = ParseNullableDouble(value),
                (r, value) => r.Comment = value
            };
        }
    }
}