using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class VersionDocument
    {
        public string ConfidentialityClass { get; set; }
        public DateTime? Created { get; set; }
        public string DocumentCategory { get; set; }
        public User DocumentOwner { get; set; }
        public IEnumerable<string> DocumentTagging { get; set; }
        public DateTime? Modified { get; set; }
        public string PlmPhase { get; set; }
        public string Title { get; set; }
        public DateTime? Updated { get; set; }
        public string Url { get; set; }
        public User CreatedBy { get; set; }
        public User ModifiedBy { get; set; }
        public User CheckoutUser { get; set; }

        public int OmItemNumber { get; set; }
        public int VersionNumber { get; set; }

    }
}
