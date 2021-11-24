using System.Collections.Generic;
using System.IO;
using CSV.Formatters;
using Domain.Entities;
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
        private const string TeamsFileName = "Teams.csv";
        private const string VersionTeamsFileName = "VersionTeams.csv";
        private const string CoSignatureHeadersFileName = "CoSignatureHeaders.csv";
        private const string VersionDocumentsFileName = "VersionDocuments.csv";
        private const string VersionChangeLogsFileName = "VersionChangeLogs.csv";
        private const string CoSignatureCoSignersFileName = "CoSigners.csv";

        private readonly AllOmItemCsvFormatter _allOmItemFormatter;
        private readonly AllVersionCsvFormatter _allVersionFormatter;
        private readonly CoSignatureHeaderFormatter _coSignatureHeaderFormatter;
        private readonly MilestoneCsvFormatter _milestonesFormatter;
        private readonly OlmPhaseCsvFormatter _olmPhaseFormatter;
        private readonly OmItemHeaderCsvFormatter _omItemHeaderFormatter;
        private readonly CsvAdapterSettings _settings;
        private readonly TeamCsvFormatter _teamsFormatter;
        private readonly VersionBudgetCsvFormatter _versionBudgetFormatter;
        private readonly VersionHeaderCsvFormatter _versionHeaderFormatter;
        private readonly VersionTeamCsvFormatter _versionTeamsFormatter;
        private readonly VersionDocumentCsvFormatter _versionDocumentsFormatter;
        private readonly VersionChangeLogCsvFormatter _versionChangeLogsFormatter;
        private readonly CoSignatureCoSignerFormatter _coSignatureCoSignerFormatter;


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
            _teamsFormatter = new TeamCsvFormatter();
            _versionTeamsFormatter = new VersionTeamCsvFormatter();
            _coSignatureHeaderFormatter = new CoSignatureHeaderFormatter();
            _versionDocumentsFormatter = new VersionDocumentCsvFormatter();
            _versionChangeLogsFormatter = new VersionChangeLogCsvFormatter();
            _coSignatureCoSignerFormatter = new CoSignatureCoSignerFormatter();
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

        public void SaveTeams(IEnumerable<Team> teams)
        {
            var path = Path.Combine(_settings.OutputDir, "omitems");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, TeamsFileName);

            var resultStream = _teamsFormatter.FormatStream(teams);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveVersionTeams(IEnumerable<VersionTeam> versionTeams)
        {
            var path = Path.Combine(_settings.OutputDir, "versions");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, VersionTeamsFileName);

            var resultStream = _versionTeamsFormatter.FormatStream(versionTeams);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveCoSignatureHeaders(IEnumerable<CoSignatureHeader> coSignatureHeaders)
        {
            var path = Path.Combine(_settings.OutputDir, "cosignatures");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, CoSignatureHeadersFileName);

            var resultStream = _coSignatureHeaderFormatter.FormatStream(coSignatureHeaders);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveVersionDocuments(IEnumerable<VersionDocument> versionDocuments)
        {
            var path = Path.Combine(_settings.OutputDir, "versions");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, VersionDocumentsFileName);

            var resultStream = _versionDocumentsFormatter.FormatStream(versionDocuments);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveVersionChangeLogs(IEnumerable<VersionChangeLog> versionChangeLogs)
        {
            var path = Path.Combine(_settings.OutputDir, "versions");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, VersionChangeLogsFileName);

            var resultStream = _versionChangeLogsFormatter.FormatStream(versionChangeLogs);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveCoSignatureCoSigners(IEnumerable<CoSignatureCoSigner> coSignatureCoSigners)
        {
            var path = Path.Combine(_settings.OutputDir, "cosignatures");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, CoSignatureCoSignersFileName);

            var resultStream = _coSignatureCoSignerFormatter.FormatStream(coSignatureCoSigners);
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
        void SaveVersionHeaders(IEnumerable<VersionHeader> versionHeaders);
        void SaveVersionBudgets(IEnumerable<VersionBudget> versionBudgets);
        void SaveTeams(IEnumerable<Team> teams);
        void SaveVersionTeams(IEnumerable<VersionTeam> versionTeams);
        void SaveCoSignatureHeaders(IEnumerable<CoSignatureHeader> coSignatureHeaders);
        void SaveVersionDocuments(IEnumerable<VersionDocument> versionDocuments);
        void SaveVersionChangeLogs(IEnumerable<VersionChangeLog> versionChangeLogs);
        void SaveCoSignatureCoSigners(IEnumerable<CoSignatureCoSigner> coSignatureCoSigners);
    }
}