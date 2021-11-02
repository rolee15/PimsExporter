using Domain.Entities;
using SharePoint;
using System.Collections.Generic;

namespace PimsExporter.Repositories
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
    }

    public interface IOmItemSiteRepository
    {
        OmItemHeader GetHeader();
        List<Milestone> GetMilestones();
        List<OlmPhase> GetOlmPhase();
    }
}