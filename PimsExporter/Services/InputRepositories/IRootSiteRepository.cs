using Domain.Entities;
using System.Collections.Generic;

namespace PimsExporter.Services.InputRepositories
{
    public interface IRootSiteRepository
    {
        List<AllOmItem> GetAllOmItems();
        List<AllVersion> GetAllVersions();
    }
}