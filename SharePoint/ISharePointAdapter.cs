using Domain.Entities;
using System.Collections.Generic;

namespace SharePoint
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
    }
}
