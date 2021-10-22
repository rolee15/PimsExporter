using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AllOmItem
    {
        public string PortfolioUnit { get; set; }
        public string OfferingName { get; set; }
        public string OfferingModule { get; set; }
        public string OfferingModuleId { get; set; }
        public string PimsId { get; set; }
        public string OmItemName { get; set; }
        public string OfferingType { get; set; }
        //TODO should be FieldUserValue and the formatter should decide how to print it (same for every other non string property)
        public string OfferingManager { get; set; }
        public string OmItemAlias { get; set; }
        public string OmItemId { get; set; }
        public string OlmCurrentPhase { get; set; }
        public string OlmPhaseStart { get; set; }
        public string OlmPhaseEnd { get; set; }
        public int OmItemNumber { get; set; }

    }
}
