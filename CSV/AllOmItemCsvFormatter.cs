using Domain.Entities;

namespace CSV
{
    public class AllOmItemCsvFormatter : DocumentFormatterBase<AllOmItem>
    {
        public AllOmItemCsvFormatter() : base(",")
        {
            Columns = new[]
            {
                new ColumnFormatter<AllOmItem>("Offering Manager", r => r.OfferingManager)
            };
        }
    }
}