using CSV;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimsExporter
{
    public class Transformer
    {
        private readonly IOutputAdapter _csvAdapter;

        public Transformer(IOutputAdapter csvAdapter)
        {
            _csvAdapter = csvAdapter;
        }

        public void TransformOmItems()
        {
            var omItemHeaders = _csvAdapter.ReadOmItemHeaders();


            var omItemOlmPhases = new List<OlmPhase>();
            var omItemMilestones = new List<Milestone>();
            var omItemTeams = new List<Team>();
            var omItemRelatedOmItems = new List<RelatedOmItem>();
            var omItemDocuments = new List<OmItemDocument>();
            
            foreach (var header in omItemHeaders)
            {
                // Delete other related objects if header is inactive
            }

        }
    }
}
