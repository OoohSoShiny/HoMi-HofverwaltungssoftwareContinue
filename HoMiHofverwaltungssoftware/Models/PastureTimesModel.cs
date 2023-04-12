using System.ComponentModel.DataAnnotations.Schema;
using System.IdentityModel.Tokens.Jwt;

namespace HoMiHofverwaltungssoftware.Models
{
    [Table("Weidezeiten")]
    public class PastureTimesModel
    {
        public int Id { get; set; }
        public int Weidegruppen_Id { get; set; }
        public int Weiden_Id { get; set; }
        public DateTime Startzeitpunkt { get; set; }
        public DateTime Endzeitpunkt { get; set;}

        public PastureTimesModel() 
        {
            Startzeitpunkt = DateTime.MinValue;
            Endzeitpunkt = DateTime.MinValue;
        }
    }
}
