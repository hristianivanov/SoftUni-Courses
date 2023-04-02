﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despatcher")]
    public class ImportDespatcherDto
    {
        [XmlElement("Name")]
        [Required, MinLength(2), MaxLength(40)]
        public string Name { get; set; }
        [Required]
        [XmlElement("Position")]
        public string Position { get; set; }
        [XmlArray("Trucks")]
        public ImportTruckDto[] Trucks { get; set; }
    }
}