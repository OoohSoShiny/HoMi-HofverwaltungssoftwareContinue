using System.ComponentModel.DataAnnotations.Schema;

namespace HoMiHofverwaltungssoftware.Models
{
    [Table("Stallnummern")]
    public class StableModel
    {
        public int Id { get; set; }
        public string? Number { get; set; }
        public Boolean Archived { get; set; }
    }
}
