using CSV.Formatters;
using CSV.Parsers;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CSV
{
    public class CsvAdapter : IOutputAdapter
    {
        private const string OmItemsFileName = "OmItems";
        private const string AllVersionsFileName = "Versions";

        private const string OmItemHeadersFileName = "OMI_Headers";
        private const string OlmPhasesFileName = "OMI_OlmPhases";
        private const string MilestonesFileName = "OMI_Milestones";
        private const string TeamsFileName = "OMI_Teams";
        private const string DocumentsFileName = "OMI_Documents";
        private const string RelatedOmItemsFileName = "OMI_RelatedOMItems";

        private const string VersionHeadersFileName = "OMIV_Headers";
        private const string VersionBudgetsFileName = "OMIV_Budgets";
        private const string VersionTeamsFileName = "OMIV_Teams";
        private const string VersionRelatedOmItemsFileName = "OMIV_RelatedOmItems";
        private const string VersionDocumentsFileName = "OMIV_Documents";
        private const string VersionChangeLogsFileName = "OMIV_ChangeLogs";
        private const string VersionMilestonesFileName = "OMIV_Milestones";

        private const string CoSignatureHeadersFileName = "CoS_Headers";
        private const string CoSignatureCoSignersFileName = "CoS_CoSigners";
        private const string CoSignatureQualitiesFileName = "CoS_Qualities";
        private const string CoSignatureDocumentsFileName = "CoS_Documents";

        private const string CsvExtension = "csv";
        private const string RootFolderName = "root";
        private const string OmItemFolderName = "omitems";
        private const string VersionsFolderName = "versions";
        private const string CoSignaturesFolderName = "cosignatures";

        private readonly AllOmItemCsvFormatter _allOmItemFormatter;
        private readonly AllVersionCsvFormatter _allVersionFormatter;
        private readonly CoSignatureCoSignerFormatter _coSignatureCoSignerFormatter;
        private readonly CoSignatureDocumentCsvFormatter _coSignatureDocumentsFormatter;
        private readonly CoSignatureHeaderFormatter _coSignatureHeaderFormatter;
        private readonly CoSignatureQualityFormatter _coSignatureQualityFormatter;
        private readonly DocumentCsvFormatter _documentsFormatter;
        private readonly MilestoneCsvFormatter _milestonesFormatter;
        private readonly OlmPhaseCsvFormatter _olmPhaseFormatter;
        private readonly OmItemHeaderCsvFormatter _omItemHeaderFormatter;
        private readonly RelatedOmItemCsvFormatter _relatedOmItemFormatter;
        private readonly CsvAdapterSettings _settings;
        private readonly TeamCsvFormatter _teamsFormatter;
        private readonly VersionBudgetCsvFormatter _versionBudgetFormatter;
        private readonly VersionChangeLogCsvFormatter _versionChangeLogsFormatter;
        private readonly VersionDocumentCsvFormatter _versionDocumentsFormatter;
        private readonly VersionHeaderCsvFormatter _versionHeaderFormatter;
        private readonly VersionMilestoneCsvFormatter _versionMilestonesFormatter;
        private readonly VersionTeamCsvFormatter _versionTeamsFormatter;
        private readonly VersionRelatedOmItemFormatter _versionRelatedOmItemFormatter;

        private readonly OmItemHeaderParser _omItemHeaderParser = new OmItemHeaderParser();
        private readonly OlmPhaseParser _olmPhaseParser = new OlmPhaseParser();
        private readonly MilestoneParser _milestoneParser = new MilestoneParser();
        private readonly TeamParser _teamParser = new TeamParser();
        private readonly RelatedOmItemParser _relatedOmItemParser = new RelatedOmItemParser();
        private readonly OmItemDocumentParser _omItemDocumentParser = new OmItemDocumentParser();
        private readonly VersionHeaderParser _versionHeaderParser = new VersionHeaderParser();
        private readonly VersionBudgetParser _versionBudgetParser = new VersionBudgetParser();
        private readonly VersionTeamParser _versionTeamParser = new VersionTeamParser();
        private readonly VersionDocumentParser _versionDocumentParser = new VersionDocumentParser();
        private readonly VersionChangeLogParser _versionChangeLogParser = new VersionChangeLogParser();
        private readonly VersionMilestoneParser _versionMilestoneParser = new VersionMilestoneParser();
        private readonly VersionRelatedOmItemParser _versionRelatedOmItemParser = new VersionRelatedOmItemParser();
        private readonly CoSignatureHeaderParser _coSignatureHeaderParser = new CoSignatureHeaderParser();
        private readonly CoSignatureDocumentParser _coSignatureDocumentParser = new CoSignatureDocumentParser();
        private readonly CoSignatureCoSignerParser _coSignatureCoSignerParser = new CoSignatureCoSignerParser();
        private readonly CoSignatureQualityParser _coSignatureQualityParser = new CoSignatureQualityParser();

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
            _coSignatureQualityFormatter = new CoSignatureQualityFormatter();
            _documentsFormatter = new DocumentCsvFormatter();
            _relatedOmItemFormatter = new RelatedOmItemCsvFormatter();
            _coSignatureDocumentsFormatter = new CoSignatureDocumentCsvFormatter();
            _versionMilestonesFormatter = new VersionMilestoneCsvFormatter();
            _versionRelatedOmItemFormatter = new VersionRelatedOmItemFormatter();
        }

        public void SaveAllVersions(IEnumerable<AllVersion> versions, int omItemNumberFrom, int omItemNumberTo, string subfolder = null)
        {
            var path = Path.Combine(_settings.OutputDir, RootFolderName);
            Directory.CreateDirectory(path);
            path = Path.Combine(path, CreateFileName(AllVersionsFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _allVersionFormatter.FormatStream(versions);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveAllOmItems(IEnumerable<AllOmItem> omItems, int omItemNumberFrom, int omItemNumberTo, string subfolder = null)
        {
            var path = Path.Combine(_settings.OutputDir, RootFolderName);
            Directory.CreateDirectory(path);
            path = Path.Combine(path, CreateFileName(OmItemsFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _allOmItemFormatter.FormatStream(omItems);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveOmItemHeaders(IEnumerable<OmItemHeader> omItemHeaders, int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null)
        {
            var path = EnsureFullPath(rootFolder, subfolder, OmItemFolderName);
            path = Path.Combine(path, CreateFileName(OmItemHeadersFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _omItemHeaderFormatter.FormatStream(omItemHeaders);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveOlmPhases(IEnumerable<OlmPhase> olmPhases, int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null)
        {
            var path = EnsureFullPath(rootFolder, subfolder, OmItemFolderName);
            path = Path.Combine(path, CreateFileName(OlmPhasesFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _olmPhaseFormatter.FormatStream(olmPhases);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveMilestones(IEnumerable<Milestone> omItemMilestones, int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null)
        {
            var path = EnsureFullPath(rootFolder, subfolder, OmItemFolderName);
            path = Path.Combine(path, CreateFileName(MilestonesFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _milestonesFormatter.FormatStream(omItemMilestones);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveTeams(IEnumerable<Team> teams, int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null)
        {
            var path = EnsureFullPath(rootFolder, subfolder, OmItemFolderName);
            path = Path.Combine(path, CreateFileName(TeamsFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _teamsFormatter.FormatStream(teams);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveDocuments(IEnumerable<OmItemDocument> documents, int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null)
        {
            var path = EnsureFullPath(rootFolder, subfolder, OmItemFolderName);
            path = Path.Combine(path, CreateFileName(DocumentsFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _documentsFormatter.FormatStream(documents);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveRelatedOmItems(IEnumerable<RelatedOmItem> relatedOmItems, int omItemNumberFrom,
            int omItemNumberTo, string rootFolder = null, string subfolder = null)
        {
            var path = EnsureFullPath(rootFolder, subfolder, OmItemFolderName);
            path = Path.Combine(path, CreateFileName(RelatedOmItemsFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _relatedOmItemFormatter.FormatStream(relatedOmItems);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveVersionHeaders(IEnumerable<VersionHeader> versionHeaders, int omItemNumberFrom,
            int omItemNumberTo, string rootFolder = null, string subfolder = null)
        {
            var path = EnsureFullPath(rootFolder, subfolder, VersionsFolderName);
            path = Path.Combine(path, CreateFileName(VersionHeadersFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _versionHeaderFormatter.FormatStream(versionHeaders);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveVersionBudgets(IEnumerable<VersionBudget> versionBudgets, int omItemNumberFrom,
            int omItemNumberTo, string rootFolder = null, string subfolder = null)
        {
            var path = EnsureFullPath(rootFolder, subfolder, VersionsFolderName);
            path = Path.Combine(path, CreateFileName(VersionBudgetsFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _versionBudgetFormatter.FormatStream(versionBudgets);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveVersionTeams(IEnumerable<VersionTeam> versionTeams, int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null)
        {
            var path = EnsureFullPath(rootFolder, subfolder, VersionsFolderName);
            path = Path.Combine(path, CreateFileName(VersionTeamsFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _versionTeamsFormatter.FormatStream(versionTeams);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveVersionDocuments(IEnumerable<VersionDocument> versionDocuments, int omItemNumberFrom,
            int omItemNumberTo, string rootFolder = null, string subfolder = null)
        {
            var path = EnsureFullPath(rootFolder, subfolder, VersionsFolderName);
            path = Path.Combine(path, CreateFileName(VersionDocumentsFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _versionDocumentsFormatter.FormatStream(versionDocuments);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveVersionChangeLogs(IEnumerable<VersionChangeLog> versionChangeLogs, int omItemNumberFrom,
            int omItemNumberTo, string rootFolder = null, string subfolder = null)
        {
            var path = EnsureFullPath(rootFolder, subfolder, VersionsFolderName);
            path = Path.Combine(path, CreateFileName(VersionChangeLogsFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _versionChangeLogsFormatter.FormatStream(versionChangeLogs);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveVersionMilestones(IEnumerable<Milestone> omIVersionMilestones, int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null)
        {
            var path = EnsureFullPath(rootFolder, subfolder, VersionsFolderName);
            path = Path.Combine(path, CreateFileName(VersionMilestonesFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _versionMilestonesFormatter.FormatStream(omIVersionMilestones);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveVersionRelatedOmItems(IEnumerable<VersionRelatedOmItem> versionRelatedOmItems, int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null)
        {
            var path = EnsureFullPath(rootFolder, subfolder, VersionsFolderName);
            path = Path.Combine(path, CreateFileName(VersionRelatedOmItemsFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _versionRelatedOmItemFormatter.FormatStream(versionRelatedOmItems);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveCoSignatureHeaders(IEnumerable<CoSignatureHeader> coSignatureHeaders, int omItemNumberFrom,
            int omItemNumberTo, string rootFolder = null, string subfolder = null)
        {
            var path = EnsureFullPath(rootFolder, subfolder, CoSignaturesFolderName);
            path = Path.Combine(path, CreateFileName(CoSignatureHeadersFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _coSignatureHeaderFormatter.FormatStream(coSignatureHeaders);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveCoSignatureCoSigners(IEnumerable<CoSignatureCoSigner> coSignatureCoSigners,
            int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null)
        {
            var path = EnsureFullPath(rootFolder, subfolder, CoSignaturesFolderName);
            path = Path.Combine(path, CreateFileName(CoSignatureCoSignersFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _coSignatureCoSignerFormatter.FormatStream(coSignatureCoSigners);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveCoSignatureQualities(IEnumerable<CoSignatureQuality> coSignatureQualities, int omItemNumberFrom,
            int omItemNumberTo, string rootFolder = null, string subfolder = null)
        {
            var path = EnsureFullPath(rootFolder, subfolder, CoSignaturesFolderName);
            path = Path.Combine(path, CreateFileName(CoSignatureQualitiesFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _coSignatureQualityFormatter.FormatStream(coSignatureQualities);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveCoSignatureDocuments(IEnumerable<CoSignatureDocument> coSignatureDocuments,
            int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null)
        {
            var path = EnsureFullPath(rootFolder, subfolder, CoSignaturesFolderName);
            path = Path.Combine(path, CreateFileName(CoSignatureDocumentsFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _coSignatureDocumentsFormatter.FormatStream(coSignatureDocuments);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public IEnumerable<OmItemHeader> ReadOmItemHeaders(string path)
        {
            string sourcePath = GetOmItemsFolderPath(path);
            var directoryInfo = new DirectoryInfo(sourcePath);

            var files = directoryInfo.GetFiles($"*.{CsvExtension}").Where(f => f.Name.StartsWith(OmItemHeadersFileName));
            if (!files.Any()) return Enumerable.Empty<OmItemHeader>();

            var rows = ReadCsv(files.First());
            return rows.Select(row => _omItemHeaderParser.ParseFields(row));

        }

        public IEnumerable<OlmPhase> ReadOlmPhases(string path)
        {
            string sourcePath = GetOmItemsFolderPath(path);
            var directoryInfo = new DirectoryInfo(sourcePath);

            var files = directoryInfo.GetFiles($"*.{CsvExtension}").Where(f => f.Name.StartsWith(OlmPhasesFileName));
            if (!files.Any()) return Enumerable.Empty<OlmPhase>();

            var rows = ReadCsv(files.First());
            return rows.Select(row => _olmPhaseParser.ParseFields(row));
        }

        public IEnumerable<Milestone> ReadMilestones(string path)
        {
            string sourcePath = GetOmItemsFolderPath(path);
            var directoryInfo = new DirectoryInfo(sourcePath);

            var files = directoryInfo.GetFiles($"*.{CsvExtension}").Where(f => f.Name.StartsWith(MilestonesFileName));
            if (!files.Any()) return Enumerable.Empty<Milestone>();

            var rows = ReadCsv(files.First());
            return rows.Select(row => _milestoneParser.ParseFields(row));
        }

        public IEnumerable<Team> ReadTeams(string path)
        {
            string sourcePath = GetOmItemsFolderPath(path);
            var directoryInfo = new DirectoryInfo(sourcePath);

            var files = directoryInfo.GetFiles($"*.{CsvExtension}").Where(f => f.Name.StartsWith(TeamsFileName));
            if (!files.Any()) return Enumerable.Empty<Team>();

            var rows = ReadCsv(files.First());
            return rows.Select(row => _teamParser.ParseFields(row));
        }

        public IEnumerable<RelatedOmItem> ReadRelatedOmItems(string path)
        {
            string sourcePath = GetOmItemsFolderPath(path);
            var directoryInfo = new DirectoryInfo(sourcePath);

            var files = directoryInfo.GetFiles($"*.{CsvExtension}").Where(f => f.Name.StartsWith(RelatedOmItemsFileName));
            if (!files.Any()) return Enumerable.Empty<RelatedOmItem>();

            var rows = ReadCsv(files.First());
            return rows.Select(row => _relatedOmItemParser.ParseFields(row));
        }

        public IEnumerable<OmItemDocument> ReadDocuments(string path)
        {
            string sourcePath = GetOmItemsFolderPath(path);
            var directoryInfo = new DirectoryInfo(sourcePath);

            var files = directoryInfo.GetFiles($"*.{CsvExtension}").Where(f => f.Name.StartsWith(DocumentsFileName));
            if (!files.Any()) return Enumerable.Empty<OmItemDocument>();

            var rows = ReadCsv(files.First());
            return rows.Select(row => _omItemDocumentParser.ParseFields(row));
        }

        public IEnumerable<VersionHeader> ReadVersionHeaders(string path)
        {
            string sourcePath = GetVersionsFolderPath(path);
            var directoryInfo = new DirectoryInfo(sourcePath);

            var files = directoryInfo.GetFiles($"*.{CsvExtension}").Where(f => f.Name.StartsWith(VersionHeadersFileName));
            if (!files.Any()) return Enumerable.Empty<VersionHeader>();

            var rows = ReadCsv(files.First());
            return rows.Select(row => _versionHeaderParser.ParseFields(row));

        }

        public IEnumerable<VersionBudget> ReadVersionBudgets(string path)
        {
            string sourcePath = GetVersionsFolderPath(path);
            var directoryInfo = new DirectoryInfo(sourcePath);

            var files = directoryInfo.GetFiles($"*.{CsvExtension}").Where(f => f.Name.StartsWith(VersionBudgetsFileName));
            if (!files.Any()) return Enumerable.Empty<VersionBudget>();

            var rows = ReadCsv(files.First());
            return rows.Select(row => _versionBudgetParser.ParseFields(row));
        }

        public IEnumerable<VersionTeam> ReadVersionTeams(string path)
        {
            string sourcePath = GetVersionsFolderPath(path);
            var directoryInfo = new DirectoryInfo(sourcePath);

            var files = directoryInfo.GetFiles($"*.{CsvExtension}").Where(f => f.Name.StartsWith(VersionTeamsFileName));
            if (!files.Any()) return Enumerable.Empty<VersionTeam>();

            var rows = ReadCsv(files.First());
            return rows.Select(row => _versionTeamParser.ParseFields(row));
        }

        public IEnumerable<VersionDocument> ReadVersionDocuments(string path)
        {
            string sourcePath = GetVersionsFolderPath(path);
            var directoryInfo = new DirectoryInfo(sourcePath);

            var files = directoryInfo.GetFiles($"*.{CsvExtension}").Where(f => f.Name.StartsWith(VersionDocumentsFileName));
            if (!files.Any()) return Enumerable.Empty<VersionDocument>();

            var rows = ReadCsv(files.First());
            return rows.Select(row => _versionDocumentParser.ParseFields(row));
        }

        public IEnumerable<VersionChangeLog> ReadVersionChangeLogs(string path)
        {
            string sourcePath = GetVersionsFolderPath(path);
            var directoryInfo = new DirectoryInfo(sourcePath);

            var files = directoryInfo.GetFiles($"*.{CsvExtension}").Where(f => f.Name.StartsWith(VersionChangeLogsFileName));
            if (!files.Any()) return Enumerable.Empty<VersionChangeLog>();

            var rows = ReadCsv(files.First());
            return rows.Select(row => _versionChangeLogParser.ParseFields(row));
        }

        public IEnumerable<Milestone> ReadVersionMilestones(string path)
        {
            string sourcePath = GetVersionsFolderPath(path);
            var directoryInfo = new DirectoryInfo(sourcePath);

            var files = directoryInfo.GetFiles($"*.{CsvExtension}").Where(f => f.Name.StartsWith(VersionMilestonesFileName));
            if (!files.Any()) return Enumerable.Empty<Milestone>();

            var rows = ReadCsv(files.First());
            return rows.Select(row => _versionMilestoneParser.ParseFields(row));
        }

        public IEnumerable<VersionRelatedOmItem> ReadVersionRelatedOmItems(string path)
        {
            string sourcePath = GetVersionsFolderPath(path);
            var directoryInfo = new DirectoryInfo(sourcePath);

            var files = directoryInfo.GetFiles($"*.{CsvExtension}").Where(f => f.Name.StartsWith(VersionRelatedOmItemsFileName));
            if (!files.Any()) return Enumerable.Empty<VersionRelatedOmItem>();

            var rows = ReadCsv(files.First());
            return rows.Select(row => _versionRelatedOmItemParser.ParseFields(row));
        }

        public IEnumerable<CoSignatureHeader> ReadCoSignatureHeaders(string path)
        {
            string sourcePath = GetCoSignaturesFolderPath(path);
            var directoryInfo = new DirectoryInfo(sourcePath);

            var files = directoryInfo.GetFiles($"*.{CsvExtension}").Where(f => f.Name.StartsWith(CoSignatureHeadersFileName));
            if (!files.Any()) return Enumerable.Empty<CoSignatureHeader>();

            var rows = ReadCsv(files.First());
            return rows.Select(row => _coSignatureHeaderParser.ParseFields(row));
        }

        public IEnumerable<CoSignatureDocument> ReadCoSignatureDocuments(string path)
        {
            string sourcePath = GetCoSignaturesFolderPath(path);
            var directoryInfo = new DirectoryInfo(sourcePath);

            var files = directoryInfo.GetFiles($"*.{CsvExtension}").Where(f => f.Name.StartsWith(CoSignatureDocumentsFileName));
            if (!files.Any()) return Enumerable.Empty<CoSignatureDocument>();

            var rows = ReadCsv(files.First());
            return rows.Select(row => _coSignatureDocumentParser.ParseFields(row));
        }

        public IEnumerable<CoSignatureCoSigner> ReadCoSignatureCoSigners(string path)
        {
            string sourcePath = GetCoSignaturesFolderPath(path);
            var directoryInfo = new DirectoryInfo(sourcePath);

            var files = directoryInfo.GetFiles($"*.{CsvExtension}").Where(f => f.Name.StartsWith(CoSignatureCoSignersFileName));
            if (!files.Any()) return Enumerable.Empty<CoSignatureCoSigner>();

            var rows = ReadCsv(files.First());
            return rows.Select(row => _coSignatureCoSignerParser.ParseFields(row));
        }

        public IEnumerable<CoSignatureQuality> ReadCoSignatureQualities(string path)
        {
            string sourcePath = GetCoSignaturesFolderPath(path);
            var directoryInfo = new DirectoryInfo(sourcePath);

            var files = directoryInfo.GetFiles($"*.{CsvExtension}").Where(f => f.Name.StartsWith(CoSignatureQualitiesFileName));
            if (!files.Any()) return Enumerable.Empty<CoSignatureQuality>();

            var rows = ReadCsv(files.First());
            return rows.Select(row => _coSignatureQualityParser.ParseFields(row));
        }

        private static string CreateFileName(string fileName, int omItemNumberFrom, int omItemNumberTo)
        {
            return $"{fileName}_{omItemNumberFrom}-{omItemNumberTo}.{CsvExtension}";
        }

        private static string GetOmItemsFolderPath(string path)
        {
            return Path.Combine(path, OmItemFolderName);
        }

        private static string GetVersionsFolderPath(string path)
        {
            return Path.Combine(path, VersionsFolderName);
        }

        private static string GetCoSignaturesFolderPath(string path)
        {
            return Path.Combine(path, CoSignaturesFolderName);
        }

        private string EnsureFullPath(string rootFolder, string subfolder, string objectType)
        {
            var path = rootFolder ?? _settings.OutputDir;
            if (subfolder != null) path = Path.Combine(path, subfolder);
            path = Path.Combine(path, objectType);
            Directory.CreateDirectory(path);
            return path;
        }

        private List<string[]> ReadCsv(FileInfo file)
        {
            var result = new List<string[]>();
            using (TextFieldParser parser = new TextFieldParser(file.FullName))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                while (!parser.EndOfData)
                {
                    //Process row
                    string[] fields = parser.ReadFields();
                    result.Add(fields);
                }
            }

            // Remove header from list
            result.RemoveAt(0);
            return result;
        }
    }

    public interface IOutputAdapter
    {
        void SaveAllOmItems(IEnumerable<AllOmItem> omItems, int omItemNumberFrom, int omItemNumberTo, string subfolder = null);
        void SaveAllVersions(IEnumerable<AllVersion> versions, int omItemNumberFrom, int omItemNumberTo, string subfolder = null);

        void SaveOmItemHeaders(IEnumerable<OmItemHeader> omItemHeaders, int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null);
        void SaveOlmPhases(IEnumerable<OlmPhase> olmPhases, int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null);
        void SaveMilestones(IEnumerable<Milestone> omItemMilestones, int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null);
        void SaveTeams(IEnumerable<Team> teams, int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null);
        void SaveDocuments(IEnumerable<OmItemDocument> documents, int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null);
        void SaveRelatedOmItems(IEnumerable<RelatedOmItem> relatedOmItems, int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null);

        void SaveVersionHeaders(IEnumerable<VersionHeader> versionHeaders, int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null);
        void SaveVersionBudgets(IEnumerable<VersionBudget> versionBudgets, int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null);
        void SaveVersionTeams(IEnumerable<VersionTeam> versionTeams, int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null);
        void SaveVersionDocuments(IEnumerable<VersionDocument> versionDocuments, int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null);
        void SaveVersionChangeLogs(IEnumerable<VersionChangeLog> versionChangeLogs, int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null);
        void SaveVersionMilestones(IEnumerable<Milestone> omIVersionMilestones, int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null);
        void SaveVersionRelatedOmItems(IEnumerable<VersionRelatedOmItem> versionRelatedOmItems, int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null);

        void SaveCoSignatureHeaders(IEnumerable<CoSignatureHeader> coSignatureHeaders, int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null);
        void SaveCoSignatureDocuments(IEnumerable<CoSignatureDocument> coSignatureDocuments, int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null);
        void SaveCoSignatureCoSigners(IEnumerable<CoSignatureCoSigner> coSignatureCoSigners, int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null);
        void SaveCoSignatureQualities(IEnumerable<CoSignatureQuality> coSignatureQualities, int omItemNumberFrom, int omItemNumberTo, string rootFolder = null, string subfolder = null);

        IEnumerable<OmItemHeader> ReadOmItemHeaders(string path);
        IEnumerable<OlmPhase> ReadOlmPhases(string path);
        IEnumerable<Milestone> ReadMilestones(string path);
        IEnumerable<Team> ReadTeams(string path);
        IEnumerable<RelatedOmItem> ReadRelatedOmItems(string path);
        IEnumerable<OmItemDocument> ReadDocuments(string path);

        IEnumerable<VersionHeader> ReadVersionHeaders(string path);
        IEnumerable<VersionBudget> ReadVersionBudgets(string path);
        IEnumerable<VersionTeam> ReadVersionTeams(string path);
        IEnumerable<VersionDocument> ReadVersionDocuments(string path);
        IEnumerable<VersionChangeLog> ReadVersionChangeLogs(string path);
        IEnumerable<Milestone> ReadVersionMilestones(string path);
        IEnumerable<VersionRelatedOmItem> ReadVersionRelatedOmItems(string path);

        IEnumerable<CoSignatureHeader> ReadCoSignatureHeaders(string path);
        IEnumerable<CoSignatureDocument> ReadCoSignatureDocuments(string path);
        IEnumerable<CoSignatureCoSigner> ReadCoSignatureCoSigners(string path);
        IEnumerable<CoSignatureQuality> ReadCoSignatureQualities(string path);
    }
}