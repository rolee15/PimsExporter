using System.Collections.Generic;
using PimsExporter.Services.InputRepositories;

namespace PimsExporter.Services
{
    public interface ILookupService
    {
        Dictionary<string, string> GetSapIds(IRootSiteRepository rootSiteRepository);
    }
}