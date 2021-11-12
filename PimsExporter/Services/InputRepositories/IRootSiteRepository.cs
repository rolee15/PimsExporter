using System.Collections.Generic;
using Domain.Entities;

namespace PimsExporter.Services.InputRepositories
{
    public interface IRootSiteRepository
    {
        IEnumerable<AllOmItem> GetAllOmItems();
        IEnumerable<AllVersion> GetAllVersions();
    }
}