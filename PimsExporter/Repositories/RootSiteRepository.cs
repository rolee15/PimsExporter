using Domain.Entities;
using PimsExporter.Entities;
using SharePoint;
using System.Collections.Generic;

namespace PimsExporter.Repositories
{

    internal class RootSiteRepository : IRootSiteRepository
    {
        private readonly ISharePointAdapter sp;

        public RootSiteRepository(ISharePointAdapter sharePointAdapter)
        {
            this.sp = sharePointAdapter;
        }

        public List<AllVersion> GetAllVersions()
        {
            return sp.AllVersions();
        }

        public List<AllOmItem> GetAllOmItems()
        {
            return sp.AllOmItems();
        }

    }

    internal interface IRootSiteRepository
    {
        List<AllOmItem> GetAllOmItems();
        List<AllVersion> GetAllVersions();
    }
}