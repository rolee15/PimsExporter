using CSV;
using Domain.Entities;
using PimsExporter.Repositories;
using SharePoint;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace PimsExporter
{
    public class Exporter
    {
        public Exporter(Uri sharepointSiteUrl, NetworkCredential credentials, string outDirPath)
        {
            SharepointSiteUrl = sharepointSiteUrl;
            Credentials = credentials;
            OutDirPath = outDirPath;
        }

        public Uri SharepointSiteUrl { get; }
        public NetworkCredential Credentials { get; }
        public string OutDirPath { get; }

        public void ExportOmItems(int from, int to)
        {
            var outputRepository = new OutputRepository(new CsvAdapter(OutDirPath));
            var omItemHeaders = new List<OmItemHeader>();
            var omItemOlmPhases = new List<OlmPhase>();
            var omItemMilestones = new List<Milestone>();
            for (int i = from; i <= to; i++)
            {
                try
                {
                    var url = Path.Combine(SharepointSiteUrl.ToString(), $"products/{i}");
                    var spAdapter = new SharePointAdapter(new Uri(url), Credentials);
                    var siteRepository = new OmItemSiteRepository(spAdapter);

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
            outputRepository.SaveOmItemHeaders(omItemHeaders);
            outputRepository.SaveOlmPhases(omItemOlmPhases);
            outputRepository.SaveMilestones(omItemMilestones);
        }

        public void ExportRoot()
        {
            var spAdapter = new SharePointAdapter(SharepointSiteUrl, Credentials);
            var rootRepository = new RootSiteRepository(spAdapter);
            var outputRepository = new OutputRepository(new CsvAdapter(OutDirPath));
            var allOmItems = rootRepository.GetAllOmItems();
            var allVersions = rootRepository.GetAllVersions();
            outputRepository.SaveAllOmItems(allOmItems);
            outputRepository.SaveAllVersions(allVersions);
        }
    }
}
