using CSV;
using Domain.Entities;
using PimsExporter.Entities;
using System.Collections.Generic;

namespace PimsExporter.Repositories
{
    internal class OutputRepository : IOutputRepository
    {
        private readonly IOutputAdapter outputAdapter;

        public OutputRepository(IOutputAdapter outputAdapter)
        {
            this.outputAdapter = outputAdapter;
        }

        public void SaveAllVersions(IEnumerable<AllVersion> versions)
        {
            outputAdapter.SaveAllVersions(versions);
        }

        public void SaveAllOmItems(IEnumerable<AllOmItem> omItems)
        {
            outputAdapter.SaveAllOmItems(omItems);
        }

        internal void SaveOmItemHeaders(IEnumerable<OmItemHeader> omItemHeaders)
        {
            outputAdapter.SaveOmItemHeaders(omItemHeaders);
        }


        internal void SaveOlmPhases(IEnumerable<OlmPhase> olmPhases)
        {
            outputAdapter.SaveOlmPhases(olmPhases);
        }
    }

        internal void SaveOmItemMilestones(IEnumerable<OmItemMilestone> omItemMilestones)
        {
            outputAdapter.SaveOmItemMilestones(omItemMilestones);
        }
    }

    internal interface IOutputRepository
    {
        void SaveAllOmItems(IEnumerable<AllOmItem> omItems);
        void SaveAllVersions(IEnumerable<AllVersion> versions);
    }
}