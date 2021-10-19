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
        }

        public string OutDirPath { get; }

        public void SaveVersions(List<AllVersion> versions)
        {
            string fileName = "versions.csv";
            string path = Path.Combine(OutDirPath, fileName);
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var version in versions)
                    sw.WriteLine(ToCsv(version));
            }
        }

        public void SaveOmItems(List<AllOmItem> omItems)
        {
            string fileName = "omitems.csv";
            string path = Path.Combine(OutDirPath, fileName);
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
    }

    public interface IOutputAdapter
    {
        void SaveVersions(List<AllVersion> versions);
    }
}
