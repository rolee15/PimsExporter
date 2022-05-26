using System;

namespace Services.Dto
{
    internal class CoSignatureQuality
    {
        public DateTime LastCheckTime { get; set; }
        public string MandatoryDocumentOrRole { get; set; }
        public string Result { get; set; }
        public bool ResultStatus { get; set; }
        public int? OptOutRuleId { get; set; }
        public string OptOutRemark { get; set; }
        public string Type { get; set; }
    }
}