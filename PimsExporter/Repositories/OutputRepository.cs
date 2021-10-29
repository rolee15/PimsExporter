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

        public void SaveOmItemHeaders(IEnumerable<OmItemHeader> omItemHeaders)
        {
            outputAdapter.SaveOmItemHeaders(omItemHeaders);
        }


        public void SaveOlmPhases(IEnumerable<OlmPhase> olmPhases)
        {
            outputAdapter.SaveOlmPhases(olmPhases);
        }

        public void SaveMilestones(IEnumerable<Milestone> milestones)
        {
            outputAdapter.SaveMilestones(milestones);
        }
    }

    internal interface IOutputRepository
    {
        void SaveAllOmItems(IEnumerable<AllOmItem> omItems);
        void SaveAllVersions(IEnumerable<AllVersion> versions);
        void SaveOmItemHeaders(IEnumerable<OmItemHeader> omItemHeaders);
        void SaveOlmPhases(IEnumerable<OlmPhase> olmPhases);
        void SaveMilestones(IEnumerable<Milestone> milestones);
    }
}