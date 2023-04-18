namespace HoMiHofverwaltungssoftware.Models
{
    public class AnimalSimpleModel
    {
        public int Id { get; set; }
        public string Ohrmarkennummer { get; set; }
        public string Stallnummer { get; set; }

        public AnimalSimpleModel()
        {
            Ohrmarkennummer = string.Empty;
            Stallnummer = string.Empty;
        }
    }
}
