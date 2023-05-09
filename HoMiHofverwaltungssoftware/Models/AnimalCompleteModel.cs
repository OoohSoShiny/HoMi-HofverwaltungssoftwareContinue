namespace HoMiHofverwaltungssoftware.Models
{
    //Model for a complete single animal with all data connected to it

    public class AnimalCompleteModel : AnimalModel
    {
        public string Vatertier { get; set; }
        public string Muttertier { get; set; }
        public List<AnimalNotesModel> AllgNotizen { get; set; }
        public List<PregnancyCheckupModel> TUNotizen { get; set; }
        public List<PastureGroupsModel> Weidegruppen { get; set; }
        public string Ordnungsgruppe { get; set; }

        public AnimalCompleteModel()
        {
            Ohrmarkennummer = string.Empty;
            Geboren = DateTime.MinValue;
            Name = string.Empty;
            Archiviert = false;
            Masttier = false;
            Vatertier = "Unbekannt";
            Muttertier = "Unbekannt";
            AllgNotizen = new List<AnimalNotesModel>();
            TUNotizen = new List<PregnancyCheckupModel>();
            Weidegruppen = new List<PastureGroupsModel>();
            Ordnungsgruppe = "Unbekannt";
        }
    }
}
