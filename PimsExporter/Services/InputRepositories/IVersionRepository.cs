using System.Collections.Generic;
using Domain.Entities;

namespace PimsExporter.Services.InputRepositories
{
    public interface IVersionRepository
    {
        VersionHeader GetHeader();
        IEnumerable<VersionBudget> GetVersionBudgets();
        IEnumerable<VersionTeam> GetVersionTeams();
    }
}