using HoMiHofverwaltungssoftware.Models;

namespace HoMiHofverwaltungssoftware.Responses
{
    public class MatingResponse
    {
        public List<MatingModel> MatingModels { get; set; }

        public MatingResponse() 
        {
            MatingModels = new List<MatingModel>();
        }
    }
}
