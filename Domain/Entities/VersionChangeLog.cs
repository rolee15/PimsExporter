using System;

namespace Domain.Entities
{
    public class VersionChangeLog
    {
        public string Event { get; set; }
        public DateTime? DateAndTimeOfChange { get; set; }
        public User User { get; set; }
        public string TypeOfChange { get; set; }
        public string ChangeSection { get; set; }

        public int OmItemNumber { get; set; }
        public int VersionNumber { get; set; }
    }
}