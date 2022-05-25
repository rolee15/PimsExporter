namespace Domain.Entities
{
    public class CoSignatureDocument : DocumentBase
    {
        public int VersionNumber { get; set; }
        public int CoSignatureId { get; set; }
    }
}