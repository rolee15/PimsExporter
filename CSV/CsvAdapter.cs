using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CSV.Formatters;
using CSV.Parsers;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;

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
        private const string ActiveItemsFolderName = "active";

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

        private readonly OmItemHeaderParser _omItemHeaderParser;


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

            _omItemHeaderParser = new OmItemHeaderParser();
        }

        public void SaveAllVersions(IEnumerable<AllVersion> versions, int omItemNumberFrom, int omItemNumberTo)
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

        public void SaveAllOmItems(IEnumerable<AllOmItem> omItems, int omItemNumberFrom, int omItemNumberTo)
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

        public void SaveOmItemHeaders(IEnumerable<OmItemHeader> omItemHeaders, int omItemNumberFrom, int omItemNumberTo)
        {
            var path = Path.Combine(_settings.OutputDir, OmItemFolderName);
            Directory.CreateDirectory(path);
            path = Path.Combine(path, CreateFileName(OmItemHeadersFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _omItemHeaderFormatter.FormatStream(omItemHeaders);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public IEnumerable<OmItemHeader> ReadOmItemHeaders()
        {            
            string sourcePath = GetOmItemsFolderPath();
            var directoryInfo = new DirectoryInfo(sourcePath);
            
            var files = directoryInfo.GetFiles($"*.{CsvExtension}").Where(f => f.Name.StartsWith(OmItemHeadersFileName));            
            if (!files.Any()) return Enumerable.Empty<OmItemHeader>();

            var rows = ReadCsv(files.First());
            return rows.Select(row => _omItemHeaderParser.ParseFields(row));
            
        }

        public void SaveActiveOmItemHeaders(IEnumerable<OmItemHeader> omItemHeaders, int omItemNumberFrom, int omItemNumberTo)
        {
            string path = Path.Combine(ActiveItemsFolderName, OmItemFolderName);
            Directory.CreateDirectory(path);
            path = Path.Combine(path, CreateFileName(OmItemHeadersFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _omItemHeaderFormatter.FormatStream(omItemHeaders);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveOlmPhases(IEnumerable<OlmPhase> olmPhases, int omItemNumberFrom, int omItemNumberTo)
        {
            var path = Path.Combine(_settings.OutputDir, OmItemFolderName);
            Directory.CreateDirectory(path);
            path = Path.Combine(path, CreateFileName(OlmPhasesFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _olmPhaseFormatter.FormatStream(olmPhases);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveMilestones(IEnumerable<Milestone> omItemMilestones, int omItemNumberFrom, int omItemNumberTo)
        {
            var path = Path.Combine(_settings.OutputDir, OmItemFolderName);
            Directory.CreateDirectory(path);
            path = Path.Combine(path, CreateFileName(MilestonesFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _milestonesFormatter.FormatStream(omItemMilestones);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveVersionMilestones(IEnumerable<Milestone> omIVersionMilestones, int omItemNumberFrom,
            int omItemNumberTo)
        {
            var path = Path.Combine(_settings.OutputDir, VersionsFolderName);
            Directory.CreateDirectory(path);
            path = Path.Combine(path, CreateFileName(VersionMilestonesFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _versionMilestonesFormatter.FormatStream(omIVersionMilestones);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveVersionHeaders(IEnumerable<VersionHeader> versionHeaders, int omItemNumberFrom,
            int omItemNumberTo)
        {
            var path = Path.Combine(_settings.OutputDir, VersionsFolderName);
            Directory.CreateDirectory(path);
            path = Path.Combine(path, CreateFileName(VersionHeadersFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _versionHeaderFormatter.FormatStream(versionHeaders);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveVersionBudgets(IEnumerable<VersionBudget> versionBudgets, int omItemNumberFrom,
            int omItemNumberTo)
        {
            var path = Path.Combine(_settings.OutputDir, VersionsFolderName);
            Directory.CreateDirectory(path);
            path = Path.Combine(path, CreateFileName(VersionBudgetsFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _versionBudgetFormatter.FormatStream(versionBudgets);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveTeams(IEnumerable<Team> teams, int omItemNumberFrom, int omItemNumberTo)
        {
            var path = Path.Combine(_settings.OutputDir, OmItemFolderName);
            Directory.CreateDirectory(path);
            path = Path.Combine(path, CreateFileName(TeamsFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _teamsFormatter.FormatStream(teams);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveVersionTeams(IEnumerable<VersionTeam> versionTeams, int omItemNumberFrom, int omItemNumberTo)
        {
            var path = Path.Combine(_settings.OutputDir, VersionsFolderName);
            Directory.CreateDirectory(path);
            path = Path.Combine(path, CreateFileName(VersionTeamsFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _versionTeamsFormatter.FormatStream(versionTeams);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveCoSignatureHeaders(IEnumerable<CoSignatureHeader> coSignatureHeaders, int omItemNumberFrom,
            int omItemNumberTo)
        {
            var path = Path.Combine(_settings.OutputDir, CoSignaturesFolderName);
            Directory.CreateDirectory(path);
            path = Path.Combine(path, CreateFileName(CoSignatureHeadersFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _coSignatureHeaderFormatter.FormatStream(coSignatureHeaders);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveVersionDocuments(IEnumerable<VersionDocument> versionDocuments, int omItemNumberFrom,
            int omItemNumberTo)
        {
            var path = Path.Combine(_settings.OutputDir, VersionsFolderName);
            Directory.CreateDirectory(path);
            path = Path.Combine(path, CreateFileName(VersionDocumentsFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _versionDocumentsFormatter.FormatStream(versionDocuments);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveVersionChangeLogs(IEnumerable<VersionChangeLog> versionChangeLogs, int omItemNumberFrom,
            int omItemNumberTo)
        {
            var path = Path.Combine(_settings.OutputDir, VersionsFolderName);
            Directory.CreateDirectory(path);
            path = Path.Combine(path, CreateFileName(VersionChangeLogsFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _versionChangeLogsFormatter.FormatStream(versionChangeLogs);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveCoSignatureCoSigners(IEnumerable<CoSignatureCoSigner> coSignatureCoSigners,
            int omItemNumberFrom, int omItemNumberTo)
        {
            var path = Path.Combine(_settings.OutputDir, CoSignaturesFolderName);
            Directory.CreateDirectory(path);
            path = Path.Combine(path, CreateFileName(CoSignatureCoSignersFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _coSignatureCoSignerFormatter.FormatStream(coSignatureCoSigners);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveCoSignatureQualities(IEnumerable<CoSignatureQuality> coSignatureQualities, int omItemNumberFrom,
            int omItemNumberTo)
        {
            var path = Path.Combine(_settings.OutputDir, CoSignaturesFolderName);
            Directory.CreateDirectory(path);
            path = Path.Combine(path, CreateFileName(CoSignatureQualitiesFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _coSignatureQualityFormatter.FormatStream(coSignatureQualities);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveVersionRelatedOmItems(List<VersionRelatedOmItem> versionRelatedOmItems, int omItemNumberFrom, int omItemNumberTo)
        {
            var path = Path.Combine(_settings.OutputDir, VersionsFolderName);
            Directory.CreateDirectory(path);
            path = Path.Combine(path, CreateFileName(VersionRelatedOmItemsFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _versionRelatedOmItemFormatter.FormatStream(versionRelatedOmItems);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveDocuments(IEnumerable<OmItemDocument> documents, int omItemNumberFrom, int omItemNumberTo)
        {
            var path = Path.Combine(_settings.OutputDir, OmItemFolderName);
            Directory.CreateDirectory(path);
            path = Path.Combine(path, CreateFileName(DocumentsFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _documentsFormatter.FormatStream(documents);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveRelatedOmItems(IEnumerable<RelatedOmItem> relatedOmItems, int omItemNumberFrom,
            int omItemNumberTo)
        {
            var path = Path.Combine(_settings.OutputDir, OmItemFolderName);
            Directory.CreateDirectory(path);
            path = Path.Combine(path, CreateFileName(RelatedOmItemsFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _relatedOmItemFormatter.FormatStream(relatedOmItems);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveCoSignatureDocuments(IEnumerable<CoSignatureDocument> coSignatureDocuments,
            int omItemNumberFrom, int omItemNumberTo)
        {
            var path = Path.Combine(_settings.OutputDir, CoSignaturesFolderName);
            Directory.CreateDirectory(path);
            path = Path.Combine(path, CreateFileName(CoSignatureDocumentsFileName, omItemNumberFrom, omItemNumberTo));

            var resultStream = _coSignatureDocumentsFormatter.FormatStream(coSignatureDocuments);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        private static string CreateFileName(string fileName, int omItemNumberFrom, int omItemNumberTo)
        {
            return $"{fileName}_{omItemNumberFrom}-{omItemNumberTo}.{CsvExtension}";
        }

        private static string GetRootFolderPath()
        {
            return Path.Combine(".", RootFolderName);
        }

        private static string GetOmItemsFolderPath()
        {
            return Path.Combine(".", OmItemFolderName);
        }

        private static string GetVersionsFolderPath()
        {
            return Path.Combine(".", VersionsFolderName);
        }

        private static string GetCoSignaturesFolderPath()
        {
            return Path.Combine(".", CoSignaturesFolderName);
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
        void SaveAllOmItems(IEnumerable<AllOmItem> omItems, int omItemNumberFrom, int omItemNumberTo);
        void SaveAllVersions(IEnumerable<AllVersion> versions, int omItemNumberFrom, int omItemNumberTo);
        void SaveOmItemHeaders(IEnumerable<OmItemHeader> omItemHeaders, int omItemNumberFrom, int omItemNumberTo);
        void SaveOlmPhases(IEnumerable<OlmPhase> olmPhases, int omItemNumberFrom, int omItemNumberTo);
        void SaveMilestones(IEnumerable<Milestone> omItemMilestones, int omItemNumberFrom, int omItemNumberTo);
        void SaveVersionHeaders(IEnumerable<VersionHeader> versionHeaders, int omItemNumberFrom, int omItemNumberTo);
        void SaveVersionBudgets(IEnumerable<VersionBudget> versionBudgets, int omItemNumberFrom, int omItemNumberTo);
        void SaveTeams(IEnumerable<Team> teams, int omItemNumberFrom, int omItemNumberTo);
        void SaveVersionTeams(IEnumerable<VersionTeam> versionTeams, int omItemNumberFrom, int omItemNumberTo);

        void SaveCoSignatureHeaders(IEnumerable<CoSignatureHeader> coSignatureHeaders, int omItemNumberFrom,
            int omItemNumberTo);

        void SaveVersionDocuments(IEnumerable<VersionDocument> versionDocuments, int omItemNumberFrom,
            int omItemNumberTo);

        void SaveVersionChangeLogs(IEnumerable<VersionChangeLog> versionChangeLogs, int omItemNumberFrom,
            int omItemNumberTo);

        void SaveVersionMilestones(IEnumerable<Milestone> omIVersionMilestones, int omItemNumberFrom,
            int omItemNumberTo);

        void SaveCoSignatureCoSigners(IEnumerable<CoSignatureCoSigner> coSignatureCoSigners, int omItemNumberFrom,
            int omItemNumberTo);

        void SaveCoSignatureQualities(IEnumerable<CoSignatureQuality> coSignatureQualities, int omItemNumberFrom,
            int omItemNumberTo);

        void SaveRelatedOmItems(IEnumerable<RelatedOmItem> relatedOmItems, int omItemNumberFrom, int omItemNumberTo);
        
        void SaveVersionRelatedOmItems(List<VersionRelatedOmItem> versionRelatedOmItems, int omItemNumberFrom, int omItemNumberTo);
        
        void SaveDocuments(IEnumerable<OmItemDocument> documents, int omItemNumberFrom, int omItemNumberTo);

        void SaveCoSignatureDocuments(IEnumerable<CoSignatureDocument> coSignatureDocuments, int omItemNumberFrom,
            int omItemNumberTo);

        IEnumerable<OmItemHeader> ReadOmItemHeaders();
    }
}