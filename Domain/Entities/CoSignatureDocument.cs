using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CoSignatureDocument : DocumentBase
    {
        public int VersionNumber { get; set; }
        public int CoSignatureId { get; set; }
    }
}
