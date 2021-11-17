using Domain.Entities;
using PimsExporter.Services.InputRepositories;
using SharePoint.Interfaces;
using System.Collections.Generic;

namespace Services.InputRepositories
{
    public class OmItemSiteRepository : IOmItemSiteRepository
    {
        private readonly ISharePointAdapter _spAdapter;

        public OmItemSiteRepository(ISharePointAdapter spAdapter)
        {
            this._spAdapter = spAdapter;
        }

        public OmItemHeader GetHeader()
        {
            return _spAdapter.ProductRecord();
        }

        public IEnumerable<OlmPhase> GetOlmPhase()
        {
            return _spAdapter.OlmPhase();
        }

        public IEnumerable<Milestone> GetMilestones()
        {
            return _spAdapter.Milestones();
        }

        public IEnumerable<int> GetVersionNumbers()
        {
            return _spAdapter.VersionNumbers();
        }

        public IEnumerable<Team> GetTeams()
        {
            return _spAdapter.Teams();
        }
    }
}