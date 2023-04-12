using System.ComponentModel.DataAnnotations.Schema;

namespace HoMiHofverwaltungssoftware.Models
{
    [Table("Weiden")]
    public class PastureModel
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }

        public PastureModel() 
        {
            Bezeichnung = string.Empty;
        }
    }
}
