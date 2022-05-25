using System;

namespace Domain.Entities
{
    public class Lookup
    {
        public string ChoiceList { get; set; }
        public string Title { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string Value { get; set; }
    }
}