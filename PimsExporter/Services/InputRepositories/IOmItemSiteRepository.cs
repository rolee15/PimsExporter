using Domain.Entities;
using System.Collections.Generic;

namespace PimsExporter.Services.InputRepositories
{
    public interface IOmItemSiteRepository
    {
        OmItemHeader GetHeader();
        IEnumerable<Milestone> GetMilestones();
        IEnumerable<OlmPhase> GetOlmPhase();
        IEnumerable<int> GetVersionNumbers();
        List<Team> GetTeams();
    }
}