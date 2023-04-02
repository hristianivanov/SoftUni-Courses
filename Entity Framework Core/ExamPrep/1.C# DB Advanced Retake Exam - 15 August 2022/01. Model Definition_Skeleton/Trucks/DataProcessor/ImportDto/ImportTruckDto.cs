using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Data.Models.Enums;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Truck")]
    public class ImportTruckDto
    {
        [XmlElement("RegistrationNumber")]
        [MaxLength(8), MinLength(8)]
        [RegularExpression(@"^[A-Z]{2}\d{4}[A-Z]{2}$")]
        public string RegistrationNumber { get; set; } = null!;
        [MaxLength(17), MinLength(17), Required]
        [XmlElement("VinNumber")]
        public string VinNumber { get; set; } = null!;
        [Range(950, 1420)]
        [XmlElement("TankCapacity")]
        public int TankCapacity { get; set; }
        [Range(5000, 29000)]
        [XmlElement("CargoCapacity")]
        public int CargoCapacity { get; set; }
        [Required]
        [XmlElement("CategoryType")]
        public int CategoryType { get; set; }
        [Required]
        [XmlElement("MakeType")]
        public int MakeType { get; set; }
    }
}