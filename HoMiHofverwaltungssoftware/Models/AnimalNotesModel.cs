using System.ComponentModel.DataAnnotations.Schema;

namespace HoMiHofverwaltungssoftware.Models
{
    [Table("Tiernotizen")]
    public class AnimalNotesModel
    {
        public int Id { get; set; }
        public string? Tiernotiz { get; set; }
    }
}