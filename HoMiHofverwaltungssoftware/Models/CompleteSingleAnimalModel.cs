namespace HoMiHofverwaltungssoftware.Models
{
    //Model for a complete single animal with all data connected to it

    public class CompleteSingleAnimalModel
    {
        public int Id { get; set; }
        public string Ordnungsgruppe { get; set; }
        public string Stallnummer { get; set; }
        public string Ohrmarkennummer { get; set; }
        public DateTime Geboren { get; set; }
        public bool Geschlecht { get; set; }
        public string Name { get; set; }
        public bool Archiviert { get; set; }
        public bool Masttier { get; set; }
        public string Vatertier { get; set; }
        public string Muttertier { get; set; }
        public List<string> AllgNotizen { get; set; }
        public List<PregnancyCheckupModel> TUNotizen { get; set; }
        public List<string> Weidegruppen { get; set; }

        public CompleteSingleAnimalModel()
        {
            Ordnungsgruppe = string.Empty;
            Stallnummer = string.Empty;
            Ohrmarkennummer = string.Empty;
            Geboren = DateTime.MinValue;
            Name = string.Empty;
            Archiviert = false;
            Masttier = false;
            Vatertier = "Unbekannt";
            Muttertier = "Unbekannt";
            AllgNotizen = new List<string>();
            TUNotizen = new List<PregnancyCheckupModel>();
            Weidegruppen = new List<string>();
        }
    }
}
