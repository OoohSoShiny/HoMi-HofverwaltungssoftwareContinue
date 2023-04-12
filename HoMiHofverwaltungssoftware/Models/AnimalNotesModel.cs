using System.ComponentModel.DataAnnotations.Schema;

namespace HoMiHofverwaltungssoftware.Models
{
    [Table("Tiernotizen")]
    public class AnimalNotesModel
    {
        public int Id { get; set; }
        public int Tiere_Id { get; set; }
        public string Notiz { get; set; }
        
        public AnimalNotesModel() 
        {
            Notiz = string.Empty;
        }
    }
}