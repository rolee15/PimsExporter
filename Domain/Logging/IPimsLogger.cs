using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimsExporter.Domain.Logging
{
    public interface IPimsLogger
    {
        void LogInfo(string message);
        void LogError(string message);
    }
}
