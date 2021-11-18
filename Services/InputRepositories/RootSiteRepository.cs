using System.Collections.Generic;
using Domain.Entities;
using PimsExporter.Services.InputRepositories;
using SharePoint.Interfaces;

namespace Services.InputRepositories
{
    public class RootSiteRepository : IRootSiteRepository
    {
        private readonly ISharePointAdapter _spAdapter;

        public RootSiteRepository(ISharePointAdapter sharePointAdapter)
        {
            _spAdapter = sharePointAdapter;
        }

        public IEnumerable<AllVersion> GetAllVersions()
        {
            return _spAdapter.AllVersions();
        }

        public IEnumerable<AllOmItem> GetAllOmItems()
        {
            return _spAdapter.AllOmItems();
        }
    }
}