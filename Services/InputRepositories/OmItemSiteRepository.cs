using System.Collections.Generic;
using Domain.Entities;
using PimsExporter.Services.InputRepositories;
using SharePoint.Interfaces;

namespace Services.InputRepositories
{
    public class OmItemSiteRepository : IOmItemSiteRepository
    {
        private readonly ISharePointAdapter _spAdapter;

        public OmItemSiteRepository(ISharePointAdapter spAdapter)
        {
            _spAdapter = spAdapter;
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
        public IEnumerable<OmItemDocument> GetDocuments()
        {
            return _spAdapter.Documents();
        }
    }
}