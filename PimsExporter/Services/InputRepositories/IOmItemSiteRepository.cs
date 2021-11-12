using System.Collections.Generic;
using Domain.Entities;

namespace PimsExporter.Services.InputRepositories
{
    public interface IOmItemSiteRepository
    {
        OmItemHeader GetHeader();
        IEnumerable<Milestone> GetMilestones();
        IEnumerable<OlmPhase> GetOlmPhase();
        IEnumerable<int> GetVersionNumbers();
        IEnumerable<Team> GetTeams();
    }
}