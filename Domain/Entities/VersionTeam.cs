using System;

namespace Domain.Entities
{
    public class VersionTeam
    {
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public string TeamRole { get; set; }
        public string RoleComment { get; set; }
        public User Member { get; set; }
        public User DeputyOf { get; set; }
        public bool CoSigner { get; set; }
        public int OmItemNumber { get; set; }
        public int VersionNumber { get; set; }
    }
}
