using CsvHelper;
using CsvHelper.Configuration;
using MetaPAL.Models;
using Readers;

namespace MetaPAL.Resources
{
    /// <summary>
    /// This class is for reading in organism tsv files downloaded from XXXX
    /// </summary>
    public class OrganismFile : ResultFile<Organism>
    {
        public override SupportedFileType FileType { get; }

        public override Software Software { get; set; }

        public OrganismFile(string filePath) : base(filePath, Software.Unspecified)
        {

        }

        public override void LoadResults()
        {
            using var csv = new CsvReader(new StreamReader(FilePath), _organismConfig);
            Results = csv.GetRecords<Organism>().ToList();
        }

        public override void WriteResults(string outputPath)
        {
            throw new NotImplementedException();
        }

        private static CsvConfiguration _organismConfig => new CsvConfiguration(cultureInfo: System.Globalization.CultureInfo.InvariantCulture)
        {
            Delimiter = "\t",
        };
    }
}
