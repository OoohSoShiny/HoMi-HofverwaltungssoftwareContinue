using System.ComponentModel.DataAnnotations.Schema;

namespace HoMiHofverwaltungssoftware.Models
{
    [Table("Ordnungsgruppen")]
    public class OrderGroupsModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
