using System.Globalization;
using Domain.Entities;

namespace CSV.Formatters
{
    internal class DocumentCsvFormatter : DocumentFormatterBase<OmItemDocument>
    {
        public DocumentCsvFormatter() : base(CultureInfo.CurrentCulture.TextInfo.ListSeparator)
        {
            Columns = new[]
            {
                new ColumnFormatter<OmItemDocument>(nameof(OmItemDocument.OmItemNumber), r => r.OmItemNumber),
                new ColumnFormatter<OmItemDocument>(nameof(OmItemDocument.Name), r => r.Name),
                new ColumnFormatter<OmItemDocument>(nameof(OmItemDocument.ConfidentialityClass),
                    r => r.ConfidentialityClass),
                new ColumnFormatter<OmItemDocument>(nameof(OmItemDocument.DocumentCategory), r => r.DocumentCategory),
                new ColumnFormatter<OmItemDocument>(nameof(OmItemDocument.DocumentTagging), r => r.DocumentTagging),
                new ColumnFormatter<OmItemDocument>(nameof(OmItemDocument.DocumentOwner), r => FormatUser(r.DocumentOwner)),
                new ColumnFormatter<OmItemDocument>(nameof(OmItemDocument.OlmPhase), r => r.OlmPhase),
                new ColumnFormatter<OmItemDocument>(nameof(OmItemDocument.Updated), r => r.Updated)
            };
        }
    }
}