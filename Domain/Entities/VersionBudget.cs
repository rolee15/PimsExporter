namespace Domain.Entities
{
    public class VersionBudget
    {
        public int Year { get; set; }
        public double? DeltaRevenuePlan { get; set; }
        public double? DeltaOEPlan { get; set; }
        public double? BSSBudgetOpexPlan { get; set; }
        public double? BSSBudgetCapexPlan { get; set; }
        public double? BSSBudgetOpexApproved { get; set; }
        public double? BSSBudgetCapexApproved { get; set; }
        public double? OSSBudgetOpexPlan { get; set; }
        public double? OSSBudgetCapexPlan { get; set; }
        public double? OSSBudgetOpexApproved { get; set; }
        public double? OSSBudgetCapexApproved { get; set; }
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