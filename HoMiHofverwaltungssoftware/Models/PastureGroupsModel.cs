using System.ComponentModel.DataAnnotations.Schema;

namespace HoMiHofverwaltungssoftware.Models
{
    [Table("Weidegruppen")]
    public class PastureGroupsModel
    {
        public int Id { get; set; }
        public string Designation { get; set; }

        public PastureGroupsModel() 
        {
            Designation = string.Empty;
        }
    }
}
