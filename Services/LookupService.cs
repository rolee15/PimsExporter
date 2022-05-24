using System.Collections.Generic;
using Domain;
using PimsExporter.Services;
using PimsExporter.Services.InputRepositories;

namespace Services
{
    public class LookupService : ILookupService
    {
        public Dictionary<string, string> GetSapIds(IRootSiteRepository rootSiteRepository)
        {
            var sapIds = new Dictionary<string, string>();
            var lookups = rootSiteRepository.GetLookups();

            foreach (var lookup in lookups)
            {
                if (!Constants.SAP_RELATED_ITEMS.Contains(lookup.ChoiceList)) continue;
                if (!sapIds.ContainsKey(lookup.Title))
                    sapIds.Add(lookup.Title, lookup.Value);
            }
            
            return sapIds;
        }
    }
}