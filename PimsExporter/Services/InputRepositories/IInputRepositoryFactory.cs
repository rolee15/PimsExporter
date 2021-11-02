using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PimsExporter.Services.InputRepositories
{
    public interface IInputRepositoryFactory
    {
        T Create<T>(Uri uri, NetworkCredential credentials) where T : class;
    }
}
