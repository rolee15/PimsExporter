using Domain.Entities;
using PimsExporter.Services.InputRepositories;
using PimsExporter.Services.OutputRepositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security;
using Microsoft.Extensions.Options;

namespace PimsExporter
{
    public class Exporter : IApplication
    {
        private readonly ExporterSettings _settings;
        private readonly IInputRepositoryFactory _inputRepositoryFactory;
        private readonly IOutputRepository _outputRepository;

        public Exporter(IOptions<ExporterSettings> settings, IInputRepositoryFactory inputRepositoryFactory, IOutputRepository outputRepository)
        {
            _settings = settings.Value;
            _inputRepositoryFactory = inputRepositoryFactory;
            _outputRepository = outputRepository;

            RootSiteUrl = _settings.SharepointUrl;
            UserName = _settings.UserName;
        }

        public string RootSiteUrl { get; private set; }
        public string UserName { get; private set; }
        public SecureString Password { get; set; }

        public void ExportOmItems(int from, int to)
        {
            var omItemHeaders = new List<OmItemHeader>();
            var omItemOlmPhases = new List<OlmPhase>();
            var omItemMilestones = new List<Milestone>();
            for (int i = from; i <= to; i++)
            {
                try
                {
                    var url = Path.Combine(RootSiteUrl, $"products/{i}");
                    var siteUri = new Uri(url);
                    var credentials = new NetworkCredential(UserName, Password);
                    var siteRepository = _inputRepositoryFactory.Create<IOmItemSiteRepository>(siteUri, credentials);

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
            var siteUri = new Uri(RootSiteUrl);
            var credentials = new NetworkCredential(UserName, Password);
            var rootRepository = _inputRepositoryFactory.Create<IRootSiteRepository>(siteUri, credentials);
            var allOmItems = rootRepository.GetAllOmItems();
            var allVersions = rootRepository.GetAllVersions();
            _outputRepository.SaveAllOmItems(allOmItems);
            _outputRepository.SaveAllVersions(allVersions);
        }
    }

    public interface IApplication
    {
        void ExportRoot();
        void ExportOmItems(int from, int to);

        SecureString Password { get; set; }
    }
}
