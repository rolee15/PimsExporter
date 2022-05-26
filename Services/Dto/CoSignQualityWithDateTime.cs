using System;
using System.Collections.Generic;

namespace Services.Dto
{
    internal class CoSignQualityWithDateTime
    {
        public double QualityIndex { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }
        public IEnumerable<CoSignatureQuality> QualityMapping { get; set; }
    }
}