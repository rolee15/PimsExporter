using System.Collections.Generic;
using Domain.Entities;

namespace PimsExporter.Services.OutputRepositories
{
    public interface IOutputRepository
    {
        void SaveAllOmItems(IEnumerable<AllOmItem> omItems);
        void SaveAllVersions(IEnumerable<AllVersion> versions);
        void SaveOmItemHeaders(IEnumerable<OmItemHeader> omItemHeaders);
        void SaveOlmPhases(IEnumerable<OlmPhase> olmPhases);
        void SaveMilestones(IEnumerable<Milestone> milestones);
        void SaveVersionHeaders(IEnumerable<VersionHeader> versionHeaders);
        void SaveVersionBudgets(IEnumerable<VersionBudget> versionBudgets);
        void SaveTeams(IEnumerable<Team> teams);
        void SaveVersionTeams(IEnumerable<VersionTeam> versionTeams);
        void SaveCoSignatureHeaders(IEnumerable<CoSignatureHeader> coSignatureHeaders);
        void SaveVersionDocuments(IEnumerable<VersionDocument> versionDocuments);
        void SaveVersionChangeLogs(IEnumerable<VersionChangeLog> versionChangeLogs);
        void SaveVersionMilestones(IEnumerable<Milestone> versionMilestones);
        void SaveCoSignatureCoSigners(IEnumerable<CoSignatureCoSigner> coSignatureCoSigners);
    }
}