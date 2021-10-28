using Domain.Entities;
using SharePoint;
using System.Collections.Generic;

namespace PimsExporter.Repositories
{
    internal class OmItemSiteRepository
    {
        private ISharePointAdapter spAdapter;

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
    }
}