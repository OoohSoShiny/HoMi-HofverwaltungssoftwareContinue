using System.ComponentModel.DataAnnotations.Schema;

namespace HoMiHofverwaltungssoftware.Models
{
    [Table("Brunftbeobachtung")]
    public class RutCheckModel
    {
        public int Id { get; set; }
        public int Tier_Id { get; set; }
        public DateTime Termin { get; set; }

        public RutCheckModel() 
        {
            Termin = DateTime.MinValue;
        }
    }
}
