using System.ComponentModel.DataAnnotations.Schema;

namespace HoMiHofverwaltungssoftware.Models
{
    //Notes for Animals which do not have to be directly connected to the Pregnancy checkups

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