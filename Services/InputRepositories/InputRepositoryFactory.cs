using PimsExporter.Services.InputRepositories;
using SharePoint;
using System;
using System.Net;

namespace Services.InputRepositories
{
    public class InputRepositoryFactory : IInputRepositoryFactory
    {
        public T Create<T>(Uri uri, NetworkCredential credentials) where T : class
        {
            var sp = new SharePointAdapter(uri, credentials);
            switch (typeof(T).Name)
            {
                case "IRootSiteRepository":
                    return new RootSiteRepository(sp) as T;
                case "IOmItemSiteRepository":
                    return new OmItemSiteRepository(sp) as T;
                case "IVersionRepository":
                    return new VersionRepository(sp) as T;
                default:
                    throw new ArgumentException("Illegal argument: {0}", typeof(T).Name);
            }
        }
    }
}