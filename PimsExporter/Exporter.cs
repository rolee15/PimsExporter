using Domain.Entities;
using Microsoft.Extensions.Options;
using PimsExporter.Services.InputRepositories;
using PimsExporter.Services.OutputRepositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;

namespace PimsExporter
{
    public class Exporter : IApplication
    {
        private readonly IInputRepositoryFactory _inputRepositoryFactory;
        private readonly IOutputRepository _outputRepository;
        private readonly ExporterSettings _settings;

        public Exporter(IOptions<ExporterSettings> settings, IInputRepositoryFactory inputRepositoryFactory,
            IOutputRepository outputRepository)
        {
            _settings = settings.Value;
            _inputRepositoryFactory = inputRepositoryFactory;
            _outputRepository = outputRepository;
        }

        public SecureString Password { get; set; }

        public void ExportOmItems(int omItemNumberFrom, int omItemNumberTo)
        {
            var omItemHeaders = new List<OmItemHeader>();
            var omItemOlmPhases = new List<OlmPhase>();
            var omItemMilestones = new List<Milestone>();
            var omItemTeams = new List<Team>();
            for (var omItemNumber = omItemNumberFrom; omItemNumber <= omItemNumberTo; omItemNumber++)
                try
                {
                    var url = Path.Combine(_settings.SharepointUrl, $"products/{omItemNumber}");
                    var siteUri = new Uri(url);
                    var credentials = new NetworkCredential(_settings.UserName, Password);
                    var siteRepository = _inputRepositoryFactory.Create<IOmItemSiteRepository>(siteUri, credentials);

                    var header = siteRepository.GetHeader();
                    header.OmItemNumber = omItemNumber;
                    omItemHeaders.Add(header);

                    var olmPhases = siteRepository.GetOlmPhase().ToList();
                    olmPhases.ForEach(o => o.OmItemNumber = omItemNumber);
                    omItemOlmPhases.AddRange(olmPhases);

                    var milestones = siteRepository.GetMilestones().ToList();
                    milestones.ForEach(m => m.OmItemNumber = omItemNumber);
                    omItemMilestones.AddRange(milestones);

                    var teams = siteRepository.GetTeams().ToList();
                    teams.ForEach(o => o.OmItemNumber = omItemNumber);
                    omItemTeams.AddRange(teams);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error at {0}: {1}", omItemNumber, ex.Message);
                }

            _outputRepository.SaveOmItemHeaders(omItemHeaders);
            _outputRepository.SaveOlmPhases(omItemOlmPhases);
            _outputRepository.SaveMilestones(omItemMilestones);
            _outputRepository.SaveTeams(omItemTeams);
        }

        public void ExportVersions(int omItemNumberFrom, int omItemNumberTo)
        {
            var versionHeaders = new List<VersionHeader>();
            var versionBudgets = new List<VersionBudget>();
            var versionTeams = new List<VersionTeam>();
            for (var omItemNumber = omItemNumberFrom; omItemNumber <= omItemNumberTo; omItemNumber++)
                try
                {
                    var omItemUrl = Path.Combine(_settings.SharepointUrl, $"products/{omItemNumber}");
                    var omItemSiteUri = new Uri(omItemUrl);
                    var credentials = new NetworkCredential(_settings.UserName, Password);
                    var omItemRepository =
                        _inputRepositoryFactory.Create<IOmItemSiteRepository>(omItemSiteUri, credentials);

                    var versionNumbers = omItemRepository.GetVersionNumbers();
                    foreach (var versionNumber in versionNumbers)
                        try
                        {
                            var url = Path.Combine(_settings.SharepointUrl, $"products/{omItemNumber}/{versionNumber}");
                            var siteUri = new Uri(url);
                            var versionRepository =
                                _inputRepositoryFactory.Create<IVersionRepository>(siteUri, credentials);

                            var header = versionRepository.GetHeader();
                            header.OmItemNumber = omItemNumber;
                            header.VersionNumber = versionNumber;
                            versionHeaders.Add(header);

                            var tempVersionBudgets = versionRepository.GetVersionBudgets().ToList();
                            foreach (var item in tempVersionBudgets)
                            {
                                item.OmItemNumber = omItemNumber;
                                item.VersionNumber = versionNumber;
                            }
                            versionBudgets.AddRange(tempVersionBudgets);

                            var tempVersionTeams = versionRepository.GetVersionTeams().ToList();
                            foreach (var item in tempVersionTeams)
                            {
                                item.OmItemNumber = omItemNumber;
                                item.VersionNumber = versionNumber;
                            }
                            versionTeams.AddRange(tempVersionTeams);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error at {0}/{1}: {2}", omItemNumber, versionNumber, ex.Message);
                        }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error at {0}: {1}", omItemNumber, ex.Message);
                }

            _outputRepository.SaveVersionHeaders(versionHeaders);
            _outputRepository.SaveVersionBudgets(versionBudgets);
            _outputRepository.SaveVersionTeams(versionTeams);
        }

        public void ExportCoSignatures(int omItemNumberFrom, int omItemNumberTo)
        {
            var coSignatureHeaders = new List<CoSignatureHeader>();

            for (var omItemNumber = omItemNumberFrom; omItemNumber <= omItemNumberTo; omItemNumber++)
                try
                {
                    var omItemUrl = Path.Combine(_settings.SharepointUrl, $"products/{omItemNumber}");
                    var omItemSiteUri = new Uri(omItemUrl);
                    var credentials = new NetworkCredential(_settings.UserName, Password);
                    var omItemRepository =
                        _inputRepositoryFactory.Create<IOmItemSiteRepository>(omItemSiteUri, credentials);

                    var versionNumbers = omItemRepository.GetVersionNumbers();
                    foreach (var versionNumber in versionNumbers)
                        try
                        {
                            var versionUrl = Path.Combine(_settings.SharepointUrl, $"products/{omItemNumber}/{versionNumber}");
                            var versionSiteUri = new Uri(versionUrl);
                            var versionRepository =
                                _inputRepositoryFactory.Create<IVersionRepository>(versionSiteUri, credentials);

                            var headers = versionRepository.GetCoSignatureHeaders().ToList();
                            foreach (var header in headers)
                            {
                                header.OmItemNumber = omItemNumber;
                                header.VersionNumber = versionNumber;
                            }
                            coSignatureHeaders.AddRange(headers);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error at {0}/{1}: {2}", omItemNumber, versionNumber, ex.Message);
                        }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error at {0}: {1}", omItemNumber, ex.Message);
                }

            _outputRepository.SaveCoSignatureHeaders(coSignatureHeaders);
        }

        public void ExportRoot()
        {
            var siteUri = new Uri(_settings.SharepointUrl);
            var credentials = new NetworkCredential(_settings.UserName, Password);
            var rootRepository = _inputRepositoryFactory.Create<IRootSiteRepository>(siteUri, credentials);
            var allOmItems = rootRepository.GetAllOmItems();
            var allVersions = rootRepository.GetAllVersions();
            _outputRepository.SaveAllOmItems(allOmItems);
            _outputRepository.SaveAllVersions(allVersions);
        }
    }

    public interface IApplication
    {
        SecureString Password { get; set; }
        void ExportRoot();
        void ExportOmItems(int omItemNumberFrom, int omItemNumberTo);
        void ExportVersions(int omItemNumberFrom, int omItemNumberTo);
        void ExportCoSignatures(int omItemNumberFrom, int omItemNumberTo);
    }
}