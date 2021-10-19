using Domain.Entities;
using PimsExporter.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV
{
    public class CsvAdapter : IOutputAdapter
    {
        public CsvAdapter(string outDirPath)
        {
            OutDirPath = outDirPath;
            Headers = new List<OmItemHeader>();
        }

        public string OutDirPath { get; }
        private List<OmItemHeader> Headers { get; }

        public void SaveAllVersions(List<AllVersion> versions)
        {
            string fileName = "versions.csv";
            string path = Path.Combine(OutDirPath, "root", fileName);
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var version in versions)
                    sw.WriteLine(ToCsv(version));
            }
        }

        public void SaveAllOmItems(List<AllOmItem> omItems)
        {
            string fileName = "omitems.csv";
            string path = Path.Combine(OutDirPath, "root", fileName);
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var omItem in omItems)
                    sw.WriteLine(ToCsv(omItem));
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

        public void AppendHeader(OmItemHeader header)
        {
            Headers.Add(header);
        }

        public void SaveOmItemHeaders()
        {
            string fileName = "omitemheaders.csv";
            string path = Path.Combine(OutDirPath, "product", fileName);
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (OmItemHeader header in Headers)
                    sw.WriteLine(ToCsv(header));
            }
        }
    }

    public interface IOutputAdapter
    {
        void AppendHeader(OmItemHeader header);
        void SaveAllOmItems(List<AllOmItem> omItems);
        void SaveAllVersions(List<AllVersion> versions);
        void SaveOmItemHeaders();
    }
}
