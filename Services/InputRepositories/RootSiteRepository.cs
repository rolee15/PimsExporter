using System.Collections.Generic;
using System.Linq;
using Domain;
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

        public Dictionary<string, string> GetSapIds()
        {
            var lookups = _spAdapter.Lookups();

            return lookups.Where(x => Constants.SAP_RELATED_ITEMS.Contains(x.ChoiceList))
                .GroupBy(x => x.Title).Select(g => g.First())
                .ToDictionary(x => x.Title, x => x.Value);
        }
    }
}