using Domain.Entities;
using System.Collections.Generic;

namespace PimsExporter.Services.InputRepositories
{
    public interface IVersionRepository
    {
        VersionHeader GetHeader();
        IEnumerable<VersionBudget> GetVersionBudgets();
    }
}