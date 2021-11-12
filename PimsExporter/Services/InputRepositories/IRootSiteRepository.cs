using Domain.Entities;
using System.Collections.Generic;

namespace PimsExporter.Services.InputRepositories
{
    public interface IRootSiteRepository
    {
        IEnumerable<AllOmItem> GetAllOmItems();
        IEnumerable<AllVersion> GetAllVersions();
    }
}