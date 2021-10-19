using CSV;
using Domain.Entities;
using PimsExporter.Entities;
using System;
using System.Collections.Generic;

namespace PimsExporter.Repositories
{
    internal class OutputRepository : IOutputRepository
    {
        private readonly IOutputAdapter outputAdapter;

        public OutputRepository(IOutputAdapter outputAdapter)
        {
            this.outputAdapter = outputAdapter;
        }

        public void SaveAllVersions(List<AllVersion> versions)
        {
            outputAdapter.SaveAllVersions(versions);
        }

        public void SaveAllOmItems(List<AllOmItem> omItems)
        {
            outputAdapter.SaveAllOmItems(omItems);
        }

        internal void AppendHeader(OmItemHeader header)
        {
            outputAdapter.AppendHeader(header);
        }

        internal void SaveOmItemHeaders()
        {
            outputAdapter.SaveOmItemHeaders();
        }
    }

    internal interface IOutputRepository
    {
        void SaveAllOmItems(List<AllOmItem> omItems);
        void SaveAllVersions(List<AllVersion> versions);
    }
}