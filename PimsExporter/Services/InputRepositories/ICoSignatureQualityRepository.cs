using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimsExporter.Services.InputRepositories
{
    public interface ICoSignatureQualityRepository
    {
        Task<IEnumerable<CoSignatureQuality>> GetCoSignatureQualitiesAsync(int omItemNumber, int versionNumber, int coSingnatureId);
    }
}
