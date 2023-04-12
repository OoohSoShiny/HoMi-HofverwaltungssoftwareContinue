using System.ComponentModel.DataAnnotations.Schema;

namespace HoMiHofverwaltungssoftware.Models
{
    [Table("Trächtigkeitsuntersuchung")]
    public class PregnancyCheckupModel
    {
        public int Id { get; set; }
        public DateTime Termin { get; set; }

        public PregnancyCheckupModel() 
        {
            Termin = DateTime.MinValue;
        }
    }
}

