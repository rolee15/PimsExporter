using CSV;
using PimsExporter.Repositories;
using SharePoint;
using System;
using System.Collections.Generic;
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
            // ExportOmItems();
            // ExportVersions();
        }

        private void ExportRoot()
        {
            var rootRepository = new RootSiteRepository(new SharePointAdapter(SharepointSiteUrl, Credentials));
            var outputRepository = new OutputRepository(new CsvAdapter(OutDirPath));
            var allVersions = rootRepository.GetAllVersions();
            outputRepository.SaveVersions(allVersions);
        }
    }
}
