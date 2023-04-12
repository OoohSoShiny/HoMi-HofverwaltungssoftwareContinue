using System.ComponentModel.DataAnnotations.Schema;

namespace HoMiHofverwaltungssoftware.Models
{
    [Table("Stallnummern")]
    public class StableModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public bool Archived { get; set; }

        public StableModel() 
        {
            Number = string.Empty;
            Archived = false;
        }
    }
}
