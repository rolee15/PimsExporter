using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace PimsExporter.Services.InputRepositories
{
    public interface ICoSignatureQualityRepository
    {
        Task<IEnumerable<CoSignatureQuality>> GetCoSignatureQualitiesAsync(int omItemNumber, int versionNumber,
            int coSignatureId);
    }
}