using Domain.Entities;
using SharePoint;
using System;

namespace PimsExporter.Repositories
{
    internal class OmItemSiteRepository
    {
        private SharePointAdapter spAdapter;

        public OmItemSiteRepository(SharePointAdapter spAdapter)
        {
            this.spAdapter = spAdapter;
        }

        public OmItemHeader GetHeader()
        {
            return spAdapter.ProductRecord();
        }
    }
}