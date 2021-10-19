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
            throw new NotImplementedException();
        }

        internal void SaveOmItemHeaders()
        {
            throw new NotImplementedException();
        }
    }

    internal interface IOutputRepository
    {
        void SaveAllOmItems(List<AllOmItem> omItems);
        void SaveAllVersions(List<AllVersion> versions);
    }
}