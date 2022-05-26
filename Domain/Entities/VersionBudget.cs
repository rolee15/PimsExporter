namespace Domain.Entities
{
    public class VersionBudget
    {
        public int Year { get; set; }
        public double? DeltaRevenuePlan { get; set; }
        public double? DeltaOePlan { get; set; }
        public double? BssBudgetOpexPlan { get; set; }
        public double? BssBudgetCapexPlan { get; set; }
        public double? BssBudgetOpexApproved { get; set; }
        public double? BssBudgetCapexApproved { get; set; }
        public double? OssBudgetOpexPlan { get; set; }
        public double? OssBudgetCapexPlan { get; set; }
        public double? OssBudgetOpexApproved { get; set; }
        public double? OssBudgetCapexApproved { get; set; }
        public double? OtherBudgetOpexPlan { get; set; }
        public double? OtherBudgetCapexPlan { get; set; }
        public double? OtherBudgetOpexApproved { get; set; }
        public double? OtherBudgetCapexApproved { get; set; }
        public double? RnDBudgetOpexPlan { get; set; }
        public double? RnDBudgetCapexPlan { get; set; }
        public double? RnDBudgetOpexApproved { get; set; }
        public double? RnDBudgetCapexApproved { get; set; }
        public string Comment { get; set; }

        public int OmItemNumber { get; set; }
        public int VersionNumber { get; set; }
    }
}