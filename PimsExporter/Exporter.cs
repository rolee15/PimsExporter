using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Threading.Tasks;
using CSV;
using Domain;
using Domain.Entities;
using Microsoft.Extensions.Options;
using PimsExporter.Services.InputRepositories;

namespace PimsExporter
{
    public class Exporter : IApplication
    {
        private readonly IInputRepositoryFactory _inputRepositoryFactory;
        private readonly IOutputAdapter _outputAdapter;
        private readonly ExporterSettings _settings;
        private Dictionary<string, string> _sapIds;

        public Exporter(
            IOptions<ExporterSettings> settings,
            IInputRepositoryFactory inputRepositoryFactory,
            IOutputAdapter outputAdapter)
        {
            _settings = settings.Value;
            _inputRepositoryFactory = inputRepositoryFactory;
            _outputAdapter = outputAdapter;
        }

        public SecureString Password { get; set; }

        public void ExportOmItems(int omItemNumberFrom, int omItemNumberTo)
        {
            var omItemHeaders = new List<OmItemHeader>();
            var omItemOlmPhases = new List<OlmPhase>();
            var omItemMilestones = new List<Milestone>();
            var omItemTeams = new List<Team>();
            var omItemRelatedOmItems = new List<RelatedOmItem>();
            var omItemDocuments = new List<OmItemDocument>();

            for (var omItemNumber = omItemNumberFrom; omItemNumber <= omItemNumberTo; omItemNumber++)
                try
                {
                    var url = Path.Combine(_settings.SharepointUrl, $"products/{omItemNumber}");
                    var siteUri = new Uri(url);
                    var credentials = new NetworkCredential(_settings.UserName, Password);
                    var siteRepository = _inputRepositoryFactory.Create<IOmItemSiteRepository>(siteUri, credentials);
                    Console.WriteLine($"Export Om Item: {url}");

                    var header = siteRepository.GetHeader();
                    header.OmItemNumber = omItemNumber;
                    header.OfferingClusterSapId = _sapIds.SafeGet(header.OfferingCluster);
                    header.OfferingModuleSapId = _sapIds.SafeGet(header.OfferingModule);
                    header.OfferingNameSapId = _sapIds.SafeGet(header.OfferingName);
                    header.PortfolioUnitSapId = _sapIds.SafeGet(header.PortfolioUnit);
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

                    var document = siteRepository.GetDocuments().ToList();
                    document.ForEach(o => o.OmItemNumber = omItemNumber);
                    omItemDocuments.AddRange(document);


                    var relatedOmItem = siteRepository.GetRelatedOmItems().ToList();
                    relatedOmItem.ForEach(o => o.OmItemNumber = omItemNumber);
                    omItemRelatedOmItems.AddRange(relatedOmItem);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error at {0}: {1}", omItemNumber, ex.Message);
                }

            _outputAdapter.SaveOmItemHeaders(omItemHeaders, omItemNumberFrom, omItemNumberTo);
            _outputAdapter.SaveOlmPhases(omItemOlmPhases, omItemNumberFrom, omItemNumberTo);
            _outputAdapter.SaveMilestones(omItemMilestones, omItemNumberFrom, omItemNumberTo);
            _outputAdapter.SaveTeams(omItemTeams, omItemNumberFrom, omItemNumberTo);
            _outputAdapter.SaveDocuments(omItemDocuments, omItemNumberFrom, omItemNumberTo);
            _outputAdapter.SaveRelatedOmItems(omItemRelatedOmItems, omItemNumberFrom, omItemNumberTo);
        }

        public void ExportVersions(int omItemNumberFrom, int omItemNumberTo)
        {
            var versionHeaders = new List<VersionHeader>();
            var versionBudgets = new List<VersionBudget>();
            var versionTeams = new List<VersionTeam>();
            var versionMilestones = new List<Milestone>();
            var versionRelatedOmItems = new List<VersionRelatedOmItem>();
            var versionDocuments = new List<VersionDocument>();
            var versionChangeLogs = new List<VersionChangeLog>();
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
                            Console.WriteLine($"Export version: {url}");

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

                            var tempVersionRelatedOmItems = versionRepository.GetVersionRelatedOmItems().ToList();
                            foreach (var item in tempVersionRelatedOmItems)
                            {
                                item.OmItemNumber = omItemNumber;
                                item.VersionNumber = versionNumber;
                            }

                            versionRelatedOmItems.AddRange(tempVersionRelatedOmItems);

                            var tempVersionDocuments = versionRepository.GetVersionDocuments().ToList();
                            foreach (var item in tempVersionDocuments)
                            {
                                item.OmItemNumber = omItemNumber;
                                item.VersionNumber = versionNumber;
                            }

                            versionDocuments.AddRange(tempVersionDocuments);


                            var tempVersionChangeLogs = versionRepository.GetVersionChangeLogs().ToList();
                            foreach (var item in tempVersionChangeLogs)
                            {
                                item.OmItemNumber = omItemNumber;
                                item.VersionNumber = versionNumber;
                            }

                            versionChangeLogs.AddRange(tempVersionChangeLogs);

                            var tempVersionMilestones = versionRepository.GetVersionMilestones().ToList();
                            foreach (var item in tempVersionMilestones)
                            {
                                item.OmItemNumber = omItemNumber;
                                item.VersionNumber = versionNumber;
                            }

                            versionMilestones.AddRange(tempVersionMilestones);
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

            _outputAdapter.SaveVersionHeaders(versionHeaders, omItemNumberFrom, omItemNumberTo);
            _outputAdapter.SaveVersionBudgets(versionBudgets, omItemNumberFrom, omItemNumberTo);
            _outputAdapter.SaveVersionTeams(versionTeams, omItemNumberFrom, omItemNumberTo);
            _outputAdapter.SaveVersionRelatedOmItems(versionRelatedOmItems, omItemNumberFrom, omItemNumberTo);
            _outputAdapter.SaveVersionDocuments(versionDocuments, omItemNumberFrom, omItemNumberTo);
            _outputAdapter.SaveVersionChangeLogs(versionChangeLogs, omItemNumberFrom, omItemNumberTo);
            _outputAdapter.SaveVersionMilestones(versionMilestones, omItemNumberFrom, omItemNumberTo);
        }

        public async Task ExportCoSignaturesAsync(int omItemNumberFrom, int omItemNumberTo)
        {
            var coSignatureHeaders = new List<CoSignatureHeader>();
            var coSignatureCoSigners = new List<CoSignatureCoSigner>();
            var coSignatureQualities = new List<CoSignatureQuality>();
            var coSignatureDocuments = new List<CoSignatureDocument>();

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
                            var versionUrl = Path.Combine(_settings.SharepointUrl,
                                $"products/{omItemNumber}/{versionNumber}");
                            var versionSiteUri = new Uri(versionUrl);
                            var versionRepository =
                                _inputRepositoryFactory.Create<IVersionRepository>(versionSiteUri, credentials);

                            var headers = versionRepository.GetCoSignatureHeaders().ToList();
                            coSignatureHeaders.AddRange(headers);

                            var cosigners = versionRepository.GetCoSignatureCoSigners().ToList();
                            foreach (var cosigner in cosigners)
                            {
                                cosigner.OmItemNumber = omItemNumber;
                                cosigner.VersionNumber = versionNumber;
                            }

                            coSignatureCoSigners.AddRange(cosigners);

                            var documents = versionRepository.GetCoSignatureDocuments().ToList();
                            foreach (var document in documents)
                            {
                                document.OmItemNumber = omItemNumber;
                                document.VersionNumber = versionNumber;
                            }

                            coSignatureDocuments.AddRange(documents);
                            
                            var apiUri = new Uri(_settings.ApiBaseUrl);
                            var coSignatureQualityRepository =
                                _inputRepositoryFactory.Create<ICoSignatureQualityRepository>(apiUri, credentials);
                            foreach (var header in headers)
                            {
                                header.OmItemNumber = omItemNumber;
                                header.VersionNumber = versionNumber;
                                Console.WriteLine(
                                    $"Export CoSignature OmItem Number: {omItemNumber} Version Number: {versionNumber} CoSignature Id: {header.CoSignatureId}");
                                var qualities = await coSignatureQualityRepository.GetCoSignatureQualitiesAsync(omItemNumber,
                                        versionNumber, header.CoSignatureId);
                                coSignatureQualities.AddRange(coSignatureQualities);
                            }
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

            _outputAdapter.SaveCoSignatureHeaders(coSignatureHeaders, omItemNumberFrom, omItemNumberTo);
            _outputAdapter.SaveCoSignatureCoSigners(coSignatureCoSigners, omItemNumberFrom, omItemNumberTo);
            _outputAdapter.SaveCoSignatureQualities(coSignatureQualities, omItemNumberFrom, omItemNumberTo);
            _outputAdapter.SaveCoSignatureDocuments(coSignatureDocuments, omItemNumberFrom, omItemNumberTo);
        }

        public void ExportRoot(int omItemNumberFrom, int omItemNumberTo)
        {
            var siteUri = new Uri(_settings.SharepointUrl);
            var credentials = new NetworkCredential(_settings.UserName, Password);
            var rootRepository = _inputRepositoryFactory.Create<IRootSiteRepository>(siteUri, credentials);
            var allOmItems = rootRepository.GetAllOmItems();
            var allVersions = rootRepository.GetAllVersions();
            _sapIds = rootRepository.GetSapIds();

            _outputAdapter.SaveAllOmItems(
                allOmItems.Where(item => omItemNumberFrom <= item.OmItemNumber && omItemNumberTo >= item.OmItemNumber),
                omItemNumberFrom, omItemNumberTo);
            _outputAdapter.SaveAllVersions(
                allVersions.Where(item => omItemNumberFrom <= item.OmItemNumber && omItemNumberTo >= item.OmItemNumber),
                omItemNumberFrom, omItemNumberTo);
        }
    }

    public interface IApplication
    {
        SecureString Password { get; set; }
        void ExportRoot(int omItemNumberFrom, int omItemNumberTo);
        void ExportOmItems(int omItemNumberFrom, int omItemNumberTo);
        void ExportVersions(int omItemNumberFrom, int omItemNumberTo);
        Task ExportCoSignaturesAsync(int omItemNumberFrom, int omItemNumberTo);
    }
}