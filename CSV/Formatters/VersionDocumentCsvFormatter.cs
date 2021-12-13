using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV.Formatters
{
    internal class VersionDocumentCsvFormatter : DocumentFormatterBase<VersionDocument>
    {
        public VersionDocumentCsvFormatter() : base(CultureInfo.CurrentCulture.TextInfo.ListSeparator)
        {
            Columns = new[]
            {
                new ColumnFormatter<VersionDocument>(nameof(VersionDocument.OmItemNumber), r => r.OmItemNumber),
                new ColumnFormatter<VersionDocument>(nameof(VersionDocument.VersionNumber), r => r.VersionNumber),
                new ColumnFormatter<VersionDocument>(nameof(VersionDocument.Name), r => r.Name),
                new ColumnFormatter<VersionDocument>(nameof(VersionDocument.ConfidentialityClass), r => r.ConfidentialityClass),
                new ColumnFormatter<VersionDocument>(nameof(VersionDocument.DocumentCategory), r => r.DocumentCategory),
                new ColumnFormatter<VersionDocument>(nameof(VersionDocument.DocumentTagging), r => r.DocumentTagging),
                new ColumnFormatter<VersionDocument>(nameof(VersionDocument.DocumentOwner), r => r.DocumentOwner),
                new ColumnFormatter<VersionDocument>(nameof(VersionDocument.OlmPhase), r => r.OlmPhase),
                new ColumnFormatter<VersionDocument>(nameof(VersionDocument.Updated), r => r.Updated)
            };
        }
    }
}
