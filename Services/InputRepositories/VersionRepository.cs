using Domain.Entities;
using PimsExporter.Services.InputRepositories;
using SharePoint;
using System.Collections.Generic;

namespace Services.InputRepositories
{
    internal class VersionRepository : IVersionRepository
    {
        private ISharePointAdapter _spAdapter;

        public VersionRepository(ISharePointAdapter sp)
        {
            _spAdapter = sp;
        }

        public VersionHeader GetHeader()
        {
            return _spAdapter.ProductVersion();
        }

        public IEnumerable<VersionBudget> GetVersionBudgets()
        {
            return _spAdapter.VersionBudgets();
        }
    }
}