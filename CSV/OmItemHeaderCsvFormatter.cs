using Domain.Entities;

namespace CSV
{
    public class OmItemHeaderCsvFormatter : DocumentFormatterBase<OmItemHeader>
    {
        public OmItemHeaderCsvFormatter() : base(",")
        {
            Columns = new[]
            {
                new ColumnFormatter<OmItemHeader>("Active Status", r => r.ActiveStatus)
            };
        }
    }
}