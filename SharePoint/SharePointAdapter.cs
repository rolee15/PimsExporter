using PimsExporter.Entities;
using System;
using System.Collections.Generic;

namespace SharePoint
{
    public class SharePointAdapter : ISharePointAdapter
    {
        public SharePointAdapter(Uri sharepointSiteUrl)
        {
            SharepointSiteUrl = sharepointSiteUrl;
        }

        public Uri SharepointSiteUrl { get; }

        public List<AllVersion> AllVersions =>
                new List<AllVersion>();
    }

    public interface ISharePointAdapter
    {
        List<AllVersion> AllVersions { get; }
    }
}
