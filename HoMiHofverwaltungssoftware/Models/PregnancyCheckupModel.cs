using System.ComponentModel.DataAnnotations.Schema;

namespace HoMiHofverwaltungssoftware.Models
{
    [Table("Traechtigkeitsuntersuchung")]
    public class PregnancyCheckupModel
    {
        public int Id { get; set; }
        public int Tiere_Id { get; set; }
        public DateTime Termin { get; set; }
        public string Notiz { get; set; }

        public PregnancyCheckupModel() 
        {
            Termin = DateTime.MinValue;
            Notiz = string.Empty;
        }
    }
}
