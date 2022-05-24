using System;

namespace Domain.Entities
{
    public class Lookup
    {
        public string ChoiceList { get; set; }
        public string Title { get; set; }
        public string MainChoice { get; set; }
        public string MainChoiceValue { get; set; }
        public string SecondaryChoice { get; set; }
        public string SecondaryChoiceValue { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public bool IsDefault { get; set; }
        public string Value { get; set; }
    }
}