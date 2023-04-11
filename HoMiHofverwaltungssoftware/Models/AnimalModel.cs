﻿using System.ComponentModel.DataAnnotations.Schema;

namespace HoMiHofverwaltungssoftware.Models
{
    [Table("Tiere")]
    public class AnimalModel
    {
        public int Id { get; set; }
        public int Ordnungsgruppen_Id { get; set; }
        public int Stallnummer_Id { get; set; }
        public string? Ohrmarkennummer { get; set; }
        public DateTime Geboren { get; set; }
        public bool? Geschlecht { get; set; }
        public string? Name { get; set; }
        public bool? Archiviert { get; set; }
        public bool? Masttier { get; set; }
    }
}
