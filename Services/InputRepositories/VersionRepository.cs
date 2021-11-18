using System.Collections.Generic;
using Domain.Entities;
using PimsExporter.Services.InputRepositories;
using SharePoint.Interfaces;

namespace Services.InputRepositories
{
    internal class VersionRepository : IVersionRepository
    {
        private readonly ISharePointAdapter _spAdapter;

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

        public IEnumerable<VersionTeam> GetVersionTeams()
        {
            return _spAdapter.VersionTeams();
        }

        public IEnumerable<CoSignatureHeader> GetCoSignatureHeaders()
        {
            return _spAdapter.CoSignatureHeaders();
        }
    }
}