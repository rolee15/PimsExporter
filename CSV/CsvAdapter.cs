using CSV.Formatters;
using Domain.Entities;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Options;

namespace CSV
{
    public class CsvAdapter : IOutputAdapter
    {
        private const string OmItemsFileName = "OmItems.csv";
        private const string AllVersionsFileName = "Versions.csv";
        private const string OmItemHeadersFileName = "OmItemHeaders.csv";
        private const string OlmPhasesFileName = "OlmPhases.csv";
        private const string MilestonesFileName = "Milestones.csv";
        private const string VersionHeadersFileName = "VersionHeaders.csv";
        private const string VersionBudgetsFileName = "VersionBudgets.csv";

        private readonly AllOmItemCsvFormatter _allOmItemFormatter;
        private readonly AllVersionCsvFormatter _allVersionFormatter;
        private readonly OmItemHeaderCsvFormatter _omItemHeaderFormatter;
        private readonly OlmPhaseCsvFormatter _olmPhaseFormatter;
        private readonly MilestoneCsvFormatter _milestonesFormatter;
        private readonly VersionHeaderCsvFormatter _versionHeaderFormatter;
        private readonly VersionBudgetCsvFormatter _versionBudgetFormatter;
        private readonly CsvAdapterSettings _settings;

        public string OutputDir { get; }

        public CsvAdapter(IOptions<CsvAdapterSettings> settings)
        {
            _settings = settings.Value;
            _allOmItemFormatter = new AllOmItemCsvFormatter();
            _allVersionFormatter = new AllVersionCsvFormatter();
            _omItemHeaderFormatter = new OmItemHeaderCsvFormatter();
            _olmPhaseFormatter = new OlmPhaseCsvFormatter();
            _milestonesFormatter = new MilestoneCsvFormatter();
            _versionHeaderFormatter = new VersionHeaderCsvFormatter();
            _versionBudgetFormatter = new VersionBudgetCsvFormatter();
        }

        public void SaveAllVersions(IEnumerable<AllVersion> versions)
        {
            var path = Path.Combine(_settings.OutputDir, "root");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, AllVersionsFileName);

            var resultStream = _allVersionFormatter.FormatStream(versions);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveAllOmItems(IEnumerable<AllOmItem> omItems)
        {
            var path = Path.Combine(_settings.OutputDir, "root");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, OmItemsFileName);

            var resultStream = _allOmItemFormatter.FormatStream(omItems);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveOmItemHeaders(IEnumerable<OmItemHeader> omItemHeaders)
        {
            var path = Path.Combine(_settings.OutputDir, "omitems");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, OmItemHeadersFileName);

            var resultStream = _omItemHeaderFormatter.FormatStream(omItemHeaders);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveOlmPhases(IEnumerable<OlmPhase> olmPhases)
        {
            var path = Path.Combine(_settings.OutputDir, "omitems");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, OlmPhasesFileName);

            var resultStream = _olmPhaseFormatter.FormatStream(olmPhases);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveMilestones(IEnumerable<Milestone> omItemMilestones)
        {
            var path = Path.Combine(_settings.OutputDir, "omitems");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, MilestonesFileName);

            var resultStream = _milestonesFormatter.FormatStream(omItemMilestones);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveVersionHeaders(IEnumerable<VersionHeader> versionHeaders)
        {
            var path = Path.Combine(_settings.OutputDir, "versions");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, VersionHeadersFileName);

            var resultStream = _versionHeaderFormatter.FormatStream(versionHeaders);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveVersionBudgets(IEnumerable<VersionBudget> versionBudgets)
        {
            var path = Path.Combine(_settings.OutputDir, "versions");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, VersionBudgetsFileName);

            var resultStream = _versionBudgetFormatter.FormatStream(versionBudgets);
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
        void SaveVersionHeaders(IEnumerable<VersionHeader> versionHeader);
        void SaveVersionBudgets(IEnumerable<VersionBudget> versionBudgets);
    }
}
