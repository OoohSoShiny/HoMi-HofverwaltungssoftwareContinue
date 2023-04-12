using HoMiHofverwaltungssoftware.Models;

namespace HoMiHofverwaltungssoftware.Responses
{
    public class PastureGroupsResponse
    {
        public List<PastureGroupsModel> PastureGroups { get; set; }

        public PastureGroupsResponse() 
        {
            PastureGroups = new List<PastureGroupsModel>();
        }
    }
}
