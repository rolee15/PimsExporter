using Domain.Entities;
using SharePoint;
using System;

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

        public OlmPhase GetOlmPhase()
        {
            return spAdapter.OlmPhase();
        }
    }
}