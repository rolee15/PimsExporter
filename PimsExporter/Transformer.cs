using CSV;
using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PimsExporter
{
    public class Transformer
    {
        private readonly IOutputAdapter _csvAdapter;

        private readonly HashSet<Tuple<int, int>> activeVersionNumbers = new HashSet<Tuple<int, int>>();

        public Transformer(IOutputAdapter csvAdapter)
        {
            _csvAdapter = csvAdapter;
        }

        public void TransformOmItems(string path)
        {
            var headers = _csvAdapter.ReadOmItemHeaders(path);

            var activeOmItemNumbers = new HashSet<int>();
            var activeHeaders = new List<OmItemHeader>();
            foreach (var header in headers)
            {
                if (header.ActiveStatus.ToUpper().Equals("TRUE"))
                {
                    activeOmItemNumbers.Add(header.OmItemNumber);
                    activeHeaders.Add(header);
                }
            }
            
            _csvAdapter.SaveOmItemHeaders(activeHeaders, 1, 700, path, "active");

            var olmPhases = _csvAdapter.ReadOlmPhases(path);
            var activeOlmPhases = olmPhases.Where(x => activeOmItemNumbers.Contains(x.OmItemNumber));
            _csvAdapter.SaveOlmPhases(activeOlmPhases, 1, 700, path, "active");

            var milestones = _csvAdapter.ReadMilestones(path);
            var activeMilestones = milestones.Where(x => activeOmItemNumbers.Contains(x.OmItemNumber));
            _csvAdapter.SaveMilestones(activeMilestones, 1, 700, path, "active");

            var teams = _csvAdapter.ReadTeams(path);
            var activeTeams = teams.Where(x => activeOmItemNumbers.Contains(x.OmItemNumber));
            _csvAdapter.SaveTeams(activeTeams, 1, 700, path, "active");

            var relatedOmItems = _csvAdapter.ReadRelatedOmItems(path);
            var activeRelatedOmItems = relatedOmItems.Where(x => activeOmItemNumbers.Contains(x.OmItemNumber));
            _csvAdapter.SaveRelatedOmItems(activeRelatedOmItems, 1, 700, path, "active");

            var documents = _csvAdapter.ReadDocuments(path);
            var activeDocuments = documents.Where(x => activeOmItemNumbers.Contains(x.OmItemNumber));
            var filteredDocuments = (IEnumerable<OmItemDocument>)FilterAspxFiles(activeDocuments);
            _csvAdapter.SaveDocuments(filteredDocuments, 1, 700, path, "active");
        }

        public void TransformVersionsAndCoSignatures(string path)
        {
            TransformVersions(path);
            TransformCoSignatures(path);
        }

        private void TransformVersions(string path)
        {
            var headers = _csvAdapter.ReadVersionHeaders(path).ToList();

            var activeHeaders = new List<VersionHeader>();
            foreach (var header in headers)
            {
                if (header.ActiveStatus)
                {
                    activeVersionNumbers.Add(new Tuple<int, int>(header.OmItemNumber, header.VersionNumber));
                    activeHeaders.Add(header);
                }
            }

            _csvAdapter.SaveVersionHeaders(activeHeaders, 1, 700, path, "active");

            var budgets = _csvAdapter.ReadVersionBudgets(path);
            var activeBudgets = budgets.Where(x => activeVersionNumbers.Contains(new Tuple<int, int>(x.OmItemNumber, x.VersionNumber)));
            _csvAdapter.SaveVersionBudgets(activeBudgets, 1, 700, path, "active");

            var teams = _csvAdapter.ReadVersionTeams(path);
            var activeTeams = teams.Where(x => activeVersionNumbers.Contains(new Tuple<int, int>(x.OmItemNumber, x.VersionNumber)));
            _csvAdapter.SaveVersionTeams(activeTeams, 1, 700, path, "active");

            var documents = _csvAdapter.ReadVersionDocuments(path);
            var activeDocuments = documents.Where(x => activeVersionNumbers.Contains(new Tuple<int, int>(x.OmItemNumber, x.VersionNumber)));
            var filteredDocuments = (IEnumerable<VersionDocument>)FilterAspxFiles(activeDocuments);
            _csvAdapter.SaveVersionDocuments(filteredDocuments, 1, 700, path, "active");

            var changeLogs = _csvAdapter.ReadVersionChangeLogs(path);
            var activeChangeLogs = changeLogs.Where(x => activeVersionNumbers.Contains(new Tuple<int, int>(x.OmItemNumber, x.VersionNumber)));
            _csvAdapter.SaveVersionChangeLogs(activeChangeLogs, 1, 700, path, "active");

            var milestones = _csvAdapter.ReadVersionMilestones(path);
            var activeMilestones = milestones.Where(x => activeVersionNumbers.Contains(new Tuple<int, int>(x.OmItemNumber, x.VersionNumber)));
            _csvAdapter.SaveVersionMilestones(activeMilestones, 1, 700, path, "active");

            var relatedOmItems = _csvAdapter.ReadVersionRelatedOmItems(path);
            var activeRelatedOmItems = relatedOmItems.Where(x => activeVersionNumbers.Contains(new Tuple<int, int>(x.OmItemNumber, x.VersionNumber)));
            _csvAdapter.SaveVersionRelatedOmItems(activeRelatedOmItems, 1, 700, path, "active");
        }

        private void TransformCoSignatures(string path)
        {
            var headers = _csvAdapter.ReadCoSignatureHeaders(path);
            
            var activeHeaders = headers.Where(x => activeVersionNumbers.Contains(new Tuple<int, int>(x.OmItemNumber, x.VersionNumber)));
            var notRfAnalysisCoSignatures = activeHeaders.Where(x => x.OlmMilestone != Constants.Milestones.RF_ANALYSIS);
            var notRfAnalysisCoSignatureIds = notRfAnalysisCoSignatures.Select(x => new Tuple<int, int, int>(x.OmItemNumber, x.VersionNumber, x.CoSignatureId)).ToHashSet();
            _csvAdapter.SaveCoSignatureHeaders(activeHeaders, 1, 700, path, "active");

            var documents = _csvAdapter.ReadCoSignatureDocuments(path);
            var activeDocuments = documents.Where(x => activeVersionNumbers.Contains(new Tuple<int, int>(x.OmItemNumber, x.VersionNumber)));
            var filteredDocuments = activeDocuments.Where(x => x.CoSignatureId != 0);
            filteredDocuments = (IEnumerable<CoSignatureDocument>)FilterAspxFiles(activeDocuments);
            filteredDocuments = filteredDocuments.Where(x => notRfAnalysisCoSignatureIds.Contains(new Tuple<int, int, int>(x.OmItemNumber, x.VersionNumber, x.CoSignatureId)));
            _csvAdapter.SaveCoSignatureDocuments(filteredDocuments, 1, 700, path, "active");

            var coSigners = _csvAdapter.ReadCoSignatureCoSigners(path);
            var activeCoSigners = coSigners.Where(x => activeVersionNumbers.Contains(new Tuple<int, int>(x.OmItemNumber, x.VersionNumber)));
            var filteredCoSigners = activeCoSigners.Where(x => notRfAnalysisCoSignatureIds.Contains(new Tuple<int, int, int>(x.OmItemNumber, x.VersionNumber, x.CoSignatureId)));
            _csvAdapter.SaveCoSignatureCoSigners(filteredCoSigners, 1, 700, path, "active");

            var qualities = _csvAdapter.ReadCoSignatureQualities(path);
            var activeQualities = qualities.Where(x => activeVersionNumbers.Contains(new Tuple<int, int>(x.OmItemNumber, x.VersionNumber)));
            var filteredQualities = activeQualities.Where(x => notRfAnalysisCoSignatureIds.Contains(new Tuple<int, int, int>(x.OmItemNumber, x.VersionNumber, x.CoSignatureId)));
            _csvAdapter.SaveCoSignatureQualities(filteredQualities, 1, 700, path, "active");
        }

        private static IEnumerable<DocumentBase> FilterDocuments(IEnumerable<DocumentBase> documents)
        {
            var result = FilterAspxFiles(documents);
            result = FilterFolders(result);
            return result;
        }

        private static IEnumerable<DocumentBase> FilterAspxFiles(IEnumerable<DocumentBase> documents)
        {
            return documents.Where(x => !x.Name.EndsWith(".aspx"));
        }

        private static IEnumerable<DocumentBase> FilterFolders(IEnumerable<DocumentBase> documents)
        {
            return documents.Where(x => x.Name.Contains("."));
        }
    }
}
