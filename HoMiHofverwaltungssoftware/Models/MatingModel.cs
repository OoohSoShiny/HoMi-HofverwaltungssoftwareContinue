using System.ComponentModel.DataAnnotations.Schema;

namespace HoMiHofverwaltungssoftware.Models
{
    [Table("Deckungen")]
    public class MatingModel
    {
        public int Id { get; set; }
        public int Muttertier { get; set; }
        public int Vatertier { get; set; }
        public int Kalb { get; set; }
    }
}
