using CSV;
using Domain.Entities;
using PimsExporter.Entities;
using System;
using System.Collections.Generic;

namespace PimsExporter.Repositories
{
    internal class OutputRepository : IOutputRepository
    {
        private readonly CsvAdapter csvAdapter;

        public OutputRepository(CsvAdapter csvAdapter)
        {
            this.csvAdapter = csvAdapter;
        }

        public void SaveAllVersions(List<AllVersion> versions)
        {
            csvAdapter.SaveVersions(versions);
        }

        public void SaveAllOmItems(List<AllOmItem> omItems)
        {
            csvAdapter.SaveOmItems(omItems);
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
        void SaveAllVersions(List<AllVersion> versions);
    }
}