using System.ComponentModel.DataAnnotations.Schema;

namespace HoMiHofverwaltungssoftware.Models
{
    [Table("Weidegruppenzuordnung")]
    public class PastureGroupConnectorModel
    {      
        public int Id { get; set; }
        public string? PastureGroupName { get; set; }
        public string? BrandNumber { get; set; }
    }
}
