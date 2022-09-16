using System;
using System.Net;
using CSV.Logging;
using PimsExporter.Services.InputRepositories;
using SharePoint;

namespace Services.InputRepositories
{
    public class InputRepositoryFactory : IInputRepositoryFactory
    {
        private readonly IPimsLogger _logger;
        public InputRepositoryFactory(IPimsLogger logger)
        {
            _logger = logger;
        }
        public T Create<T>(Uri uri, NetworkCredential credentials) where T : class
        {
            var sp = SharePointAdapter.GetInstance(uri, credentials, _logger);
            switch (typeof(T).Name)
            {
                case "IRootSiteRepository":
                    return new RootSiteRepository(sp) as T;
                case "IOmItemSiteRepository":
                    return new OmItemSiteRepository(sp) as T;
                case "IVersionRepository":
                    return new VersionRepository(sp) as T;
                case "ICoSignatureQualityRepository":
                    return new CoSignatureQualityRepository(uri, credentials) as T;
                default:
                    throw new ArgumentException("Illegal argument: {0}", typeof(T).Name);
            }
        }
    }
}