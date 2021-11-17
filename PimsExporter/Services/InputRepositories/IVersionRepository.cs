using Domain.Entities;
using System.Collections.Generic;

namespace PimsExporter.Services.InputRepositories
{
    public interface IVersionRepository
    {
        VersionHeader GetHeader();
        IEnumerable<VersionBudget> GetVersionBudgets();
        IEnumerable<VersionTeam> GetVersionTeams();
        IEnumerable<CoSignatureHeader> GetCoSignatureHeaders();
    }
}