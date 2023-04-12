using System.ComponentModel.DataAnnotations.Schema;

namespace HoMiHofverwaltungssoftware.Models
{
    [Table("Weidegruppenzuordnung")]
    public class PastureGroupConnectorModel
    {      
        public int Id { get; set; }
        public int Tiere_Id { get; set; }
        public int Weidegruppen_Id { get; set; }
    }
}
