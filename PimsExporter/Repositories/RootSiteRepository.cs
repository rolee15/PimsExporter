﻿using Domain.Entities;
using PimsExporter.Entities;
using SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return sp.AllVersions();
        }

        internal List<AllOmItem> GetAllOmItems()
        {
            return sp.AllOmItems();
        }
    }
}