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

        public void ExportAll()
        {
            ExportRoot();
            //ExportOmItems(0, 100);
            // ExportVersions();
        }

        private void ExportOmItems(int from, int to)
        {
            var outputRepository = new OutputRepository(new CsvAdapter(OutDirPath));
            for (int i = from; i < to; i++)
            {
                var url = Path.Combine(SharepointSiteUrl.ToString(), "products/{i}");
                var spAdapter = new SharePointAdapter(SharepointSiteUrl, Credentials);
                var siteRepository = new OmItemSiteRepository(spAdapter);                
                var header = siteRepository.GetHeader();
                outputRepository.AppendHeader(header);
            }
            outputRepository.SaveOmItemHeaders();
        }

        private void ExportRoot()
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
