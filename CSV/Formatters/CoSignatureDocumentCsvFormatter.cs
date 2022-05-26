using System.Globalization;
using Domain.Entities;

namespace CSV.Formatters
{
    internal class CoSignatureDocumentCsvFormatter : DocumentFormatterBase<CoSignatureDocument>
    {
        public CoSignatureDocumentCsvFormatter() : base(CultureInfo.CurrentCulture.TextInfo.ListSeparator)
        {
            Columns = new[]
            {
                new ColumnFormatter<CoSignatureDocument>(nameof(CoSignatureDocument.OmItemNumber), r => r.OmItemNumber),
                new ColumnFormatter<CoSignatureDocument>(nameof(CoSignatureDocument.VersionNumber),
                    r => r.VersionNumber),
                new ColumnFormatter<CoSignatureDocument>(nameof(CoSignatureDocument.CoSignatureId),
                    r => r.CoSignatureId),
                new ColumnFormatter<CoSignatureDocument>(nameof(CoSignatureDocument.Name), r => r.Name),
                new ColumnFormatter<CoSignatureDocument>(nameof(CoSignatureDocument.ConfidentialityClass),
                    r => r.ConfidentialityClass),
                new ColumnFormatter<CoSignatureDocument>(nameof(CoSignatureDocument.DocumentCategory),
                    r => r.DocumentCategory),
                new ColumnFormatter<CoSignatureDocument>(nameof(CoSignatureDocument.DocumentTagging),
                    r => r.DocumentTagging),
                new ColumnFormatter<CoSignatureDocument>(nameof(CoSignatureDocument.DocumentOwner),
                    r => r.DocumentOwner),
                new ColumnFormatter<CoSignatureDocument>(nameof(CoSignatureDocument.OlmPhase), r => r.OlmPhase),
                new ColumnFormatter<CoSignatureDocument>(nameof(CoSignatureDocument.Updated), r => r.Updated)
            };
        }
    }
}