using Domain.Entities;
using PimsExporter.Services.InputRepositories;
using SharePoint;
using System.Collections.Generic;

namespace Services.InputRepositories
{
    public class OmItemSiteRepository : IOmItemSiteRepository
    {
        private readonly ISharePointAdapter spAdapter;

        public OmItemSiteRepository(ISharePointAdapter spAdapter)
        {
            this.spAdapter = spAdapter;
        }

        public OmItemHeader GetHeader()
        {
            return spAdapter.ProductRecord();
        }

        public List<OlmPhase> GetOlmPhase()
        {
            return spAdapter.OlmPhase();
        }

        public List<Milestone> GetMilestones()
        {
            return spAdapter.Milestones();
        }

        public List<int> GetVersionNumbers()
        {
            return spAdapter.VersionNumbers();
        }
    }
}