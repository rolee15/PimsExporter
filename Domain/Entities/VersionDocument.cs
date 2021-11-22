using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class VersionDocument
    {

        public string Name { get; set; }
        public string ConfidentialityClass { get; set; }
        public string DocumentCategory { get; set; }
        public IEnumerable<string> DocumentTagging { get; set; }
        public User DocumentOwner { get; set; }
        public User CheckoutTo { get; set; }

        public int OmItemNumber { get; set; }
        public int VersionNumber { get; set; }



    }
}
