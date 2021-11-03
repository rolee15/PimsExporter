using Domain.Entities;

namespace PimsExporter.Services.InputRepositories
{
    public interface IVersionRepository
    {
        VersionHeader GetHeader();
    }
}