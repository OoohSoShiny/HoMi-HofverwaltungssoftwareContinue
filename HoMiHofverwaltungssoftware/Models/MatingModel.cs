using System.ComponentModel.DataAnnotations.Schema;

namespace HoMiHofverwaltungssoftware.Models
{
    [Table("Deckungen")]
    public class MatingModel
    {
        public int Id { get; set; }
        public string? Muttertier { get; set; }
        public string? Vatertier { get; set; }
        public string? Kalb { get; set; }
    }
}
