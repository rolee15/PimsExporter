using Domain.Entities;
using PimsExporter.Services.InputRepositories;
using SharePoint;

namespace Services.InputRepositories
{
    internal class VersionRepository : IVersionRepository
    {
        private ISharePointAdapter _spAdapter;

        public VersionRepository(ISharePointAdapter sp)
        {
            this._spAdapter = sp;
        }

        public VersionHeader GetHeader()
        {
            return _spAdapter.ProductVersion();
        }
    }
}