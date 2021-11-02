using Domain.Entities;
using PimsExporter.Entities;
using SharePoint;
using System.Collections.Generic;

namespace PimsExporter.Repositories
{
    public class RootSiteRepository : IRootSiteRepository
    {
        private readonly ISharePointAdapter _spAdapter;

        public RootSiteRepository(ISharePointAdapter sharePointAdapter)
        {
            this._spAdapter = sharePointAdapter;
        }

        public List<AllVersion> GetAllVersions()
        {
            return _spAdapter.AllVersions();
        }

        public List<AllOmItem> GetAllOmItems()
        {
            return _spAdapter.AllOmItems();
        }

    }

    public interface IRootSiteRepository
    {
        List<AllOmItem> GetAllOmItems();
        List<AllVersion> GetAllVersions();
    }
}