using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dto
{
    internal class CoSignQualityWithDateTime
    {
        public double QualityIndex { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }
        public IEnumerable<CoSignatureQuality> QualityMapping { get; set; }
    }
}
