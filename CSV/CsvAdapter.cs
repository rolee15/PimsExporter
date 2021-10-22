using Domain.Entities;
using PimsExporter.Entities;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSV
{
    public class CsvAdapter : IOutputAdapter
    {
        private const string OmItemHeadersFileName = "omitemheaders.csv";
        private const string AllVersionsFileName = "versions.csv";
        private const string OmItemsFileName = "omitems.csv";

        private readonly OmItemHeaderCsvFormatter _omItemHeaderFormatter;
        private readonly AllOmItemCsvFormatter _allOmItemFormatter;
        
        public CsvAdapter(string outDirPath)
        {
            OutDirPath = outDirPath;
            _omItemHeaderFormatter = new OmItemHeaderCsvFormatter();
            _allOmItemFormatter = new AllOmItemCsvFormatter();
        }

        public string OutDirPath { get; }

        public void SaveAllVersions(List<AllVersion> versions)
        {
            var path = Path.Combine(OutDirPath, "root", AllVersionsFileName);
            Directory.CreateDirectory(path);
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var version in versions)
                    sw.WriteLine(ToCsv(version));
            }
        }

        public void SaveAllOmItems(List<AllOmItem> omItems)
        {
            string path = Path.Combine(OutDirPath, "root", OmItemsFileName);
            Directory.CreateDirectory(path);
            
            var resultStream = _allOmItemFormatter.FormatAsync(omItems);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        private string ToCsv(AllOmItem omItem)
        {
            var sb = new StringBuilder();
            sb.Append(omItem.PortfolioUnit + ";");
            sb.Append(omItem.OfferingName + ";");
            sb.Append(omItem.OfferingModule + ";");
            sb.Append(omItem.OfferingModuleId + ";");
            sb.Append(omItem.PimsId + ";");
            sb.Append(omItem.OmItemName + ";");
            sb.Append(omItem.OfferingType + ";");
            sb.Append(omItem.OfferingManager + ";");
            sb.Append(omItem.OmItemAlias + ";");
            sb.Append(omItem.OmItemId + ";");
            sb.Append(omItem.OlmCurrentPhase + ";");
            sb.Append(omItem.OlmPhaseStart + ";");
            sb.Append(omItem.OlmPhaseEnd + ";");

            return sb.ToString();
        }

        private string ToCsv(AllVersion version)
        {
            var sb = new StringBuilder();
            sb.Append(version.PortfolioUnit + ";");
            sb.Append(version.OmItemName + ";");
            sb.Append(version.OmItemId + ";");
            sb.Append(version.PimsId + ";");
            sb.Append(version.VersionName + ";");
            sb.Append(version.FullVersionId + ";");
            sb.Append(version.VersionOfferingType + ";");
            sb.Append(version.CurrentOlmPhase + ";");
            sb.Append(version.PuReleaseAssignment + ";");
            sb.Append(version.BssReleaseAssignment + ";");
            sb.Append(version.OssReleaseAssignment + ";");
            sb.Append(version.Comment);

            return sb.ToString();
        }

        private string ToCsv(OmItemHeader header)
        {
            var sb = new StringBuilder();
            sb.Append(header.OmItemName + ";");
            sb.Append(header.OmItemAlias + ";");
            sb.Append(header.OmItemId + ";");
            sb.Append(header.OfferingManager + ";");
            sb.Append(header.PortfolioUnit + ";");
            sb.Append(header.PimsId + ";");
            sb.Append(header.OfferingName + ";");
            sb.Append(header.OfferingModule + ";");
            sb.Append(header.ActiveStatus + ";");
            sb.Append(header.OlmCurrentPhase + ";");
            sb.Append(header.ConfidentialityClass + ";");
            sb.Append(header.OfferingType + ";");
            sb.Append(header.CurrentStart + ";");
            sb.Append(header.CurrentEnd + ";");
            sb.Append(header.OfferingCluster + ";");
            sb.Append(header.ShortDescription + ";");
            sb.Append(header.LongDescription);

            return sb.ToString();
        }
        
        public void SaveOmItemHeaders(IEnumerable<OmItemHeader> omItemHeaders)
        {
            var path = Path.Combine(OutDirPath, "product", OmItemHeadersFileName);
            Directory.CreateDirectory(path);
            
            var resultStream = _omItemHeaderFormatter.FormatAsync(omItemHeaders);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }
    }

    public interface IOutputAdapter
    {
        void SaveAllOmItems(List<AllOmItem> omItems);
        void SaveAllVersions(List<AllVersion> versions);
        void SaveOmItemHeaders(IEnumerable<OmItemHeader> omItemHeaders);
    }
}
