using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CoSignatureQuality
    {
        public int OmItemNumber { get; set; }
        public int VersionNumber { get; set; }
        public int CoSignatureId { get; set; }
        public DateTime LastCheckTime { get; set; }
        public string MandatoryDocumentOrRole { get; set; }
        public string Result { get; set; }
        public bool ResultStatus { get; set; }
        public bool IsOptOut { get; set; }
        public string OptOutRemark { get; set; }
        public string Type { get; set; }
        public string CoSignatureQualityIndex { get; set; }
    }
}
