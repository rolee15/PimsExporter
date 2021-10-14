using PimsExporter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV
{
    public class CsvAdapter : IOutputAdapter
    {
        public CsvAdapter(string outDirPath)
        {
            OutDirPath = outDirPath;
        }

        public string OutDirPath { get; }

        public void SaveVersions(List<AllVersion> versions)
        {
            throw new NotImplementedException();
        }
    }

    public interface IOutputAdapter
    {
        void SaveVersions(List<AllVersion> versions);
    }
}
