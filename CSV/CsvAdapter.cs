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
        private readonly AllVersionCsvFormatter _allVersionFormatter;
        
        private readonly string _outDirPath;
        
        public CsvAdapter(string outDirPath)
        {
            _outDirPath = outDirPath;
            _omItemHeaderFormatter = new OmItemHeaderCsvFormatter();
            _allOmItemFormatter = new AllOmItemCsvFormatter();
            _allVersionFormatter = new AllVersionCsvFormatter();
        }
        
        public void SaveAllVersions(List<AllVersion> versions)
        {
            var path = Path.Combine(_outDirPath, "root");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, AllVersionsFileName);
            
            var resultStream = _allVersionFormatter.FormatAsync(versions);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveAllOmItems(List<AllOmItem> omItems)
        {
            var path = Path.Combine(_outDirPath, "root");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, OmItemsFileName);
            
            var resultStream = _allOmItemFormatter.FormatAsync(omItems);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveOmItemHeaders(IEnumerable<OmItemHeader> omItemHeaders)
        {
            var path = Path.Combine(_outDirPath, "product");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, OmItemHeadersFileName);

            var resultStream = _omItemHeaderFormatter.FormatAsync(omItemHeaders);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }
        private string ToCsv(OlmPhase olmPhase)
        {
            var sb = new StringBuilder();
            sb.Append(olmPhase.OlmPhaseName + ";");
            sb.Append(olmPhase.CurrentPhase + ";");
            sb.Append(olmPhase.PhaseStartApprovalDate + ";");
            sb.Append(olmPhase.PhaseStartDate + ";");
            sb.Append(olmPhase.PhasePlannedEndDate + ";");
            sb.Append(olmPhase.PhaseDuration + ";");
            sb.Append(olmPhase.ShortDescription + ";");
            sb.Append(olmPhase.LongDescription + ";");

            return sb.ToString();
        }

        public void AppendOlmPhase(OlmPhase olmPhase)
        {
            OlmPhases.Add(olmPhase);
        }
        public void SaveOlmPhases()
        {
            string fileName = "olmphases.csv";
            string path = Path.Combine(OutDirPath, "olmphase", fileName);
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (OlmPhase olm in OlmPhases)
                    sw.WriteLine(ToCsv(olm));
            }
        }
    }

    public interface IOutputAdapter
    {
        void AppendOlmPhase(OlmPhase olmPhase);
        void SaveAllOmItems(List<AllOmItem> omItems);
        void SaveAllVersions(List<AllVersion> versions);
        void SaveOlmPhases();
        void SaveOmItemHeaders(IEnumerable<OmItemHeader> omItemHeaders);
    }
}
