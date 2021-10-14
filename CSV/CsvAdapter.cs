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

        private string ToCsv(AllVersion version)
        {
            var sb = new StringBuilder();
            sb.Append(version.PortfolioUnit + ",");
            sb.Append(version.OmItemName + ",");
            sb.Append(version.OmItemId + ",");
            sb.Append(version.PimsId + ",");
            sb.Append(version.VersionName + ",");
            sb.Append(version.FullVersionId + ",");
            sb.Append(version.VersionOfferingType + ",");
            sb.Append(version.CurrentOlmPhase + ",");
            sb.Append(version.PuReleaseAssignment + ",");
            sb.Append(version.BssReleaseAssignment + ",");
            sb.Append(version.OssReleaseAssignment + ",");
            sb.Append(version.Comment);

            return sb.ToString();
        }
    }

    public interface IOutputAdapter
    {
        void SaveVersions(List<AllVersion> versions);
    }
}
