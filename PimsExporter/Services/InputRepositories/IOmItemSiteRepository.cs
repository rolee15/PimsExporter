using Domain.Entities;
using System.Collections.Generic;

namespace PimsExporter.Services.InputRepositories
{
    public interface IOmItemSiteRepository
    {
        OmItemHeader GetHeader();
        List<Milestone> GetMilestones();
        List<OlmPhase> GetOlmPhase();
        List<int> GetVersionNumbers();
        List<Team> GetTeams();
    }
}