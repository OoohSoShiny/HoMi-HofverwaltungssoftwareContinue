using System.ComponentModel.DataAnnotations.Schema;

namespace HoMiHofverwaltungssoftware.Models
{
    [Table("Weiden")]
    public class PastureModel
    {
        public int Id { get; set; }
        public string Designation { get; set; }

        public PastureModel() 
        {
            Designation = string.Empty;
        }
    }
}
