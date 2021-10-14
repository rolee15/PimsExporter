using CSV;
using PimsExporter.Entities;
using System.Collections.Generic;

namespace PimsExporter.Repositories
{
    internal class OutputRepository : IOutputRepository
    {
        private CsvAdapter csvAdapter;

        public OutputRepository(CsvAdapter csvAdapter)
        {
            this.csvAdapter = csvAdapter;
        }

        public void SaveVersions(List<AllVersion> versions)
        {
            csvAdapter.SaveVersions(versions);
        }
    }

    internal interface IOutputRepository
    {
        void SaveVersions(List<AllVersion> versions);
    }
}