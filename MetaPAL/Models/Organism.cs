using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MetaPAL.Models
{
    public class Organism
    {
        [Key]
        [Name("Proteome Id")]
        public string ProteomeId { get; set; }
        [Name("Organism")]
        public string Name { get; set; }
        [Name("Organism Id")]
        public int OrganismId { get; set; }
    }
}
