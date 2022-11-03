using Domain.Entities;
using System;

namespace CSV.Parsers
{
    internal class VersionDocumentParser : CsvParser<VersionDocument>
    {
        public VersionDocumentParser()
        {
            Parsers = new Action<VersionDocument, string>[]
            {
                (r, value) => r.OmItemNumber = int.Parse(value),
                (r, value) => r.VersionNumber = int.Parse(value),
                (r, value) => r.Name = value,
                (r, value) => r.ConfidentialityClass = value,
                (r, value) => r.DocumentCategory = value,
                (r, value) => r.DocumentTagging = ParseListOfStrings(value),
                (r, value) => r.DocumentOwner = ParseUser(value),
                (r, value) => r.OlmPhase = value,
                (r, value) => r.Updated = ParseNullableDate(value),
                (r, value) => r.Url = value
            };
        }
    }
}