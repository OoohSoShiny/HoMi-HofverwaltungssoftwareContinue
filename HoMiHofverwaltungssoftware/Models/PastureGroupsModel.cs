using System.ComponentModel.DataAnnotations.Schema;

namespace HoMiHofverwaltungssoftware.Models
{
    [Table("Weidegruppen")]
    public class PastureGroupsModel
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }

        public PastureGroupsModel() 
        {
            Bezeichnung = string.Empty;
        }
        public PastureGroupsModel(int id, string bezeichnung)
        {
            Id = id;
            Bezeichnung = bezeichnung;
        }
    }
}
