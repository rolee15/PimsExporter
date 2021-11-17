using Domain.Entities;
using System.Collections.Generic;

namespace SharePoint.Interfaces
{
    public interface ISharePointAdapter
    {
        IEnumerable<AllOmItem> AllOmItems();
        IEnumerable<AllVersion> AllVersions();
        OmItemHeader ProductRecord();
        IEnumerable<OlmPhase> OlmPhase();
        IEnumerable<Milestone> Milestones();
        VersionHeader ProductVersion();
        IEnumerable<int> VersionNumbers();
        IEnumerable<VersionBudget> VersionBudgets();
        IEnumerable<Team> Teams();
        IEnumerable<VersionTeam> VersionTeams();
        IEnumerable<CoSignatureHeader> CoSignatureHeaders();
    }
}