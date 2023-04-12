using HoMiHofverwaltungssoftware.Models;

namespace HoMiHofverwaltungssoftware.Responses
{
    public class StableResponse
    {
        public List<StableNumberModel> Stables { get; set; }

        public StableResponse() 
        {
            Stables = new List<StableNumberModel>();
        }
    }
}
