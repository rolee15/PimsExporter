using System.Collections.Generic;
using CSV;
using Domain.Entities;
using PimsExporter.Services.OutputRepositories;

namespace Services.OutputRepositories
{
    public class OutputRepository : IOutputRepository
    {
        private readonly IOutputAdapter _outputAdapter;

        public OutputRepository(IOutputAdapter outputAdapter)
        {
            _outputAdapter = outputAdapter;
        }

        public void SaveAllVersions(IEnumerable<AllVersion> versions)
        {
            _outputAdapter.SaveAllVersions(versions);
        }

        public void SaveAllOmItems(IEnumerable<AllOmItem> omItems)
        {
            _outputAdapter.SaveAllOmItems(omItems);
        }

        public void SaveOmItemHeaders(IEnumerable<OmItemHeader> omItemHeaders)
        {
            _outputAdapter.SaveOmItemHeaders(omItemHeaders);
        }

        public void SaveOlmPhases(IEnumerable<OlmPhase> olmPhases)
        {
            _outputAdapter.SaveOlmPhases(olmPhases);
        }

        public void SaveMilestones(IEnumerable<Milestone> milestones)
        {
            _outputAdapter.SaveMilestones(milestones);
        }

        public void SaveVersionHeaders(IEnumerable<VersionHeader> versionHeaders)
        {
            _outputAdapter.SaveVersionHeaders(versionHeaders);
        }

        public void SaveVersionBudgets(IEnumerable<VersionBudget> versionBudgets)
        {
            _outputAdapter.SaveVersionBudgets(versionBudgets);
        }

        public void SaveTeams(IEnumerable<Team> teams)
        {
            _outputAdapter.SaveTeams(teams);
        }

        public void SaveVersionTeams(IEnumerable<VersionTeam> versionTeams)
        {
            _outputAdapter.SaveVersionTeams(versionTeams);
        }

        public void SaveCoSignatureHeaders(IEnumerable<CoSignatureHeader> coSignatureHeaders)
        {
            _outputAdapter.SaveCoSignatureHeaders(coSignatureHeaders);
        }

        public void SaveVersionDocuments(IEnumerable<VersionDocument> versionDocuments)
        {
            _outputAdapter.SaveVersionDocuments(versionDocuments);
        }

        public void SaveVersionChangeLogs(IEnumerable<VersionChangeLog> versionChangeLogs)
        {
            _outputAdapter.SaveVersionChangeLogs(versionChangeLogs);
        }

        public void SaveVersionMilestones(IEnumerable<Milestone> versionMilestones)
        {
            _outputAdapter.SaveVersionMilestones(versionMilestones);
        }
        
        public void SaveCoSignatureCoSigners(IEnumerable<CoSignatureCoSigner> coSignatureCoSigners)
        {
            _outputAdapter.SaveCoSignatureCoSigners(coSignatureCoSigners);
        }

        public void SaveCoSignatureQualities(IEnumerable<CoSignatureQuality> coSignatureQualities)
        {
            _outputAdapter.SaveCoSignatureQualities(coSignatureQualities);
        }

        public void SaveDocuments(IEnumerable<OmItemDocument> omItemDocuments)
        {
            _outputAdapter.SaveDocuments(omItemDocuments);
        }

        public void SaveRelatedOMItems(IEnumerable<RelatedOMItem> omItemRelatedOMItems)
        {
            _outputAdapter.SaveRelatedOMItems(omItemRelatedOMItems);
		}
		
        public void SaveCoSignatureDocuments(IEnumerable<CoSignatureDocument> coSignatureDocuments)
        {
            _outputAdapter.SaveCoSignatureDocuments(coSignatureDocuments);
        }
    }
}