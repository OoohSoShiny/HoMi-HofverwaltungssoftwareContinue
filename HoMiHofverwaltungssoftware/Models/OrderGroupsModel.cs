using System.ComponentModel.DataAnnotations.Schema;

namespace HoMiHofverwaltungssoftware.Models
{
    [Table("Ordnungsgruppen")]
    public class OrderGroupsModel
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }

        public OrderGroupsModel() 
        {
            Bezeichnung = string.Empty;
        }
    }

}
