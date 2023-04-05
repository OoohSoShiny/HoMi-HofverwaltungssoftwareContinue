namespace HoMiHofverwaltungssoftware.Models
{
    public class AnimalModel
    {
        public int Id { get; set; }
        public int Stallnummer { get; set; }
        public string? Ohrmarkennummer { get; set; }
        public DateTime Geboren { get; set; }
        public Boolean? Geschlecht { get; set; }
        public string? Tiername { get; set; }
        public Boolean Archiviert { get; set; }
        public Boolean Masttier { get; set; }
        public List<AnimalNotesModel>? Notizen { get; set; }
    }
}
