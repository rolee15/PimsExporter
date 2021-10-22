using Domain.Entities;
using PimsExporter.Entities;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSV
{
    public class CsvAdapter : IOutputAdapter
    {
        private const string OmItemHeadersFileName = "omitemheaders.csv";
        private const string AllVersionsFileName = "versions.csv";
        private const string OmItemsFileName = "omitems.csv";

        private readonly OmItemHeaderCsvFormatter _omItemHeaderFormatter;
        private readonly AllOmItemCsvFormatter _allOmItemFormatter;
        private readonly AllVersionCsvFormatter _allVersionFormatter;
        
        private readonly string _outDirPath;
        
        public CsvAdapter(string outDirPath)
        {
            _outDirPath = outDirPath;
            _omItemHeaderFormatter = new OmItemHeaderCsvFormatter();
            _allOmItemFormatter = new AllOmItemCsvFormatter();
            _allVersionFormatter = new AllVersionCsvFormatter();
        }
        
        public void SaveAllVersions(List<AllVersion> versions)
        {
            var path = Path.Combine(_outDirPath, "root", AllVersionsFileName);
            Directory.CreateDirectory(_outDirPath);
            
            var resultStream = _allVersionFormatter.FormatAsync(versions);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveAllOmItems(List<AllOmItem> omItems)
        {
            string path = Path.Combine(_outDirPath, "root", OmItemsFileName);
            Directory.CreateDirectory(_outDirPath);
            
            var resultStream = _allOmItemFormatter.FormatAsync(omItems);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }

        public void SaveOmItemHeaders(IEnumerable<OmItemHeader> omItemHeaders)
        {
            var path = Path.Combine(_outDirPath, "product", OmItemHeadersFileName);
            Directory.CreateDirectory(_outDirPath);
            
            var resultStream = _omItemHeaderFormatter.FormatAsync(omItemHeaders);
            using (var fileStream = File.Create(path))
            {
                resultStream.CopyTo(fileStream);
            }
        }
    }

    public interface IOutputAdapter
    {
        void SaveAllOmItems(List<AllOmItem> omItems);
        void SaveAllVersions(List<AllVersion> versions);
        void SaveOmItemHeaders(IEnumerable<OmItemHeader> omItemHeaders);
    }
}
