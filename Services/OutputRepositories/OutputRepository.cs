using CSV;
using Domain.Entities;
using PimsExporter.Services.OutputRepositories;
using System.Collections.Generic;

namespace Services.OutputRepositories
{
    public class OutputRepository : IOutputRepository
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

        public void SaveVersionHeaders(IEnumerable<VersionHeader> versionHeaders)
        {
            outputAdapter.SaveVersionHeaders(versionHeaders);
        }
    }
}