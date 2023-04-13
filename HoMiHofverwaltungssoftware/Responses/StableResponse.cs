using HoMiHofverwaltungssoftware.Models;

namespace HoMiHofverwaltungssoftware.Responses
{
    public class StableResponse
    {
        public List<StableNumberModel> StableNumbers { get; set; }

        public StableResponse() 
        {
            StableNumbers = new List<StableNumberModel>();
        }
    }
}
