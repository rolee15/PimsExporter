using CSV;
using PimsExporter.Repositories;
using SharePoint;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

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
            var olmPhases = new List<OlmPhase>();
            for (int i = from; i < to; i++)
            {
                try
                {
                    var url = Path.Combine(SharepointSiteUrl.ToString(), $"products/{i}");
                    var spAdapter = new SharePointAdapter(new Uri(url), Credentials);
                    var siteRepository = new OmItemSiteRepository(spAdapter);
                    var header = siteRepository.GetHeader();
                    header.OmItemNumber = i;
                    omItemHeaders.Add(header);
                    var olmPhase = siteRepository.GetOlmPhase();
                    olmPhase.ForEach(o => o.OmItemNumber = i);
                    olmPhases.AddRange(olmPhase);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            outputRepository.SaveOmItemHeaders(omItemHeaders);
            outputRepository.SaveOlmPhases(olmPhases);
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
