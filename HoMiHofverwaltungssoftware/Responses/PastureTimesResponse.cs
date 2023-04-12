using HoMiHofverwaltungssoftware.Models;

namespace HoMiHofverwaltungssoftware.Responses
{
    public class PastureTimesResponse
    {
        public List<PastureTimesModel> PastureTimes { get; set; }

        public PastureTimesResponse() 
        {
            PastureTimes = new List<PastureTimesModel>();
        }
    }
}
