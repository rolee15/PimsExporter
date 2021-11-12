using System;
using System.Net;

namespace PimsExporter.Services.InputRepositories
{
    public interface IInputRepositoryFactory
    {
        T Create<T>(Uri uri, NetworkCredential credentials) where T : class;
    }
}