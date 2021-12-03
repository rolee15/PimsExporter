using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV.Formatters
{
    internal class DocumentCsvFormatter : DocumentFormatterBase<Document>
    {
        public DocumentCsvFormatter() : base(CultureInfo.CurrentCulture.TextInfo.ListSeparator)
        {
            Columns = new[]
            {
                new ColumnFormatter<Document>(nameof(Document.OmItemNumber), r => r.OmItemNumber),
                new ColumnFormatter<Document>(nameof(Document.VersionNumber), r => r.VersionNumber),
                new ColumnFormatter<Document>(nameof(Document.CoSignatureId), r => r.CoSignatureId),
                new ColumnFormatter<Document>(nameof(Document.Name), r => r.Name),
                new ColumnFormatter<Document>(nameof(Document.ConfidentialityClass), r => r.ConfidentialityClass),
                new ColumnFormatter<Document>(nameof(Document.DocumentCategory), r => r.DocumentCategory),
                new ColumnFormatter<Document>(nameof(Document.DocumentTagging), r => r.DocumentTagging),
                new ColumnFormatter<Document>(nameof(Document.DocumentOwner), r => r.DocumentOwner),
                new ColumnFormatter<Document>(nameof(Document.CheckoutTo), r => r.CheckoutTo),
                new ColumnFormatter<Document>(nameof(Document.Updated), r => r.Updated),
                
            };
        }
    }
}
