using CSV;
using Domain.Entities;
using PimsExporter.Services.InputRepositories;
using PimsExporter.Services.OutputRepositories;
using SharePoint;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace PimsExporter
{
    public class Exporter
    {
        private readonly IInputRepositoryFactory _inputRepositoryFactory;
        private readonly IOutputRepository _outputRepository;

        public Exporter(IInputRepositoryFactory inputRepositoryFactory, IOutputRepository outputRepository)
        {
            _inputRepositoryFactory = inputRepositoryFactory;
            _outputRepository = outputRepository;
        }

        public Uri SharepointSiteUrl { get; set; }
        public NetworkCredential Credentials { get; set; }

        public void ExportOmItems(int from, int to)
        {
            var omItemHeaders = new List<OmItemHeader>();
            var omItemOlmPhases = new List<OlmPhase>();
            var omItemMilestones = new List<Milestone>();
            for (int i = from; i <= to; i++)
            {
                try
                {
                    var url = Path.Combine(SharepointSiteUrl.ToString(), $"products/{i}");
                    var spUri = new Uri(url);
                    var siteRepository = _inputRepositoryFactory.Create<IOmItemSiteRepository>(spUri, Credentials);

                    var header = siteRepository.GetHeader();
                    header.OmItemNumber = i;
                    omItemHeaders.Add(header);

                    var olmPhases = siteRepository.GetOlmPhase();
                    olmPhases.ForEach(o => o.OmItemNumber = i);
                    omItemOlmPhases.AddRange(olmPhases);

                    var milestones = siteRepository.GetMilestones();
                    milestones.ForEach(m => m.OmItemNumber = i);
                    omItemMilestones.AddRange(milestones);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            _outputRepository.SaveOmItemHeaders(omItemHeaders);
            _outputRepository.SaveOlmPhases(omItemOlmPhases);
            _outputRepository.SaveMilestones(omItemMilestones);
        }

        public void ExportRoot()
        {
            var rootRepository = _inputRepositoryFactory.Create<IRootSiteRepository>(SharepointSiteUrl, Credentials);
            var allOmItems = rootRepository.GetAllOmItems();
            var allVersions = rootRepository.GetAllVersions();
            _outputRepository.SaveAllOmItems(allOmItems);
            _outputRepository.SaveAllVersions(allVersions);
        }
    }
}
