using PimsExporter.Entities;
using SharePoint;
using System;
using System.Collections.Generic;

namespace PimsExporter.Repositories
{
    internal class RootSiteRepository
    {
        private ISharePointAdapter sp;

        public RootSiteRepository(ISharePointAdapter sharePointAdapter)
        {
            this.sp = sharePointAdapter;
        }

        internal List<AllVersion> GetAllVersions()
        {
            return sp.AllVersions;
        }
    }
}