using System.ComponentModel.DataAnnotations.Schema;

namespace HoMiHofverwaltungssoftware.Models
{
    [Table("Stallnummern")]
    public class StableNumberModel
    {
        public int Id { get; set; }
        public string Nummer { get; set; }
        public bool Archiviert { get; set; }

        public StableNumberModel() 
        {
            Nummer = string.Empty;
            Archiviert = false;
        }
    }
}
