using PimsExporter.Services.InputRepositories;
using SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
                default:
                    throw new ArgumentException("Illegal argument: {0}", nameof(T));
            }
        }
    }
}
