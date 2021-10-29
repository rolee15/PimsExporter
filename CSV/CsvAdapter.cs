using Domain.Entities;
using PimsExporter.Entities;
using System.Collections.Generic;
using System.IO;

namespace CSV
{
    public class CsvAdapter : IOutputAdapter
    {
        private const string OmItemsFileName = "OmItems.csv";
        private const string AllVersionsFileName = "Versions.csv";
        private const string OmItemHeadersFileName = "OmItemHeaders.csv";
        private const string OlmPhasesFileName = "OlmPhases.csv";
        private const string MilestonesFileName = "Milestones.csv";

        private readonly AllOmItemCsvFormatter _allOmItemFormatter;
        private readonly AllVersionCsvFormatter _allVersionFormatter;
        private readonly OmItemHeaderCsvFormatter _omItemHeaderFormatter;
        private readonly OlmPhaseCsvFormatter _olmPhaseFormatter;
        private readonly OmItemMilestonesCsvFormatter _milestonesFormatter;

        private readonly string _outDirPath;

        public CsvAdapter(string outDirPath)
        {
            _outDirPath = outDirPath;
            _allOmItemFormatter = new AllOmItemCsvFormatter();
            _allVersionFormatter = new AllVersionCsvFormatter();
            _omItemHeaderFormatter = new OmItemHeaderCsvFormatter();
            _olmPhaseFormatter = new OlmPhaseCsvFormatter();
            _milestonesFormatter = new OmItemMilestonesCsvFormatter();
        }

        public void SaveAllVersions(IEnumerable<AllVersion> versions)
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

        public void SaveAllOmItems(IEnumerable<AllOmItem> omItems)
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

        public void SaveOlmPhases(IEnumerable<OlmPhase> olmPhases)
        {
            var path = Path.Combine(_outDirPath, "product");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, OlmPhasesFileName);

            var resultStream = _olmPhaseFormatter.FormatAsync(olmPhases);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveMilestones(IEnumerable<Milestone> omItemMilestones)
        {
            var path = Path.Combine(_outDirPath, "product");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, MilestonesFileName);

            var resultStream = _milestonesFormatter.FormatAsync(omItemMilestones);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }
    }

    public interface IOutputAdapter
    {
        void SaveAllOmItems(IEnumerable<AllOmItem> omItems);
        void SaveAllVersions(IEnumerable<AllVersion> versions);
        void SaveOmItemHeaders(IEnumerable<OmItemHeader> omItemHeaders);
        void SaveOlmPhases(IEnumerable<OlmPhase> olmPhases);
        void SaveMilestones(IEnumerable<Milestone> omItemMilestones);
    }
}
