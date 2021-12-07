using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RelatedOMItem
    {
        public int OmItemNumber { get; set; }
        public string LinkType { get; set; }
        public string ShortDescription { get; set; }
        public string PimsLink { get; set; }
    }
}
