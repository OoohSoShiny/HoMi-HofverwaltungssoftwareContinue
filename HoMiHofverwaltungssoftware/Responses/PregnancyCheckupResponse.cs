using HoMiHofverwaltungssoftware.Controllers;
using HoMiHofverwaltungssoftware.Models;

namespace HoMiHofverwaltungssoftware.Responses
{
    public class PregnancyCheckupResponse
    {
        public List<PregnancyCheckupModel> PregnancyCheckups { get; set; }

        public PregnancyCheckupResponse() 
        {
            PregnancyCheckups = new List<PregnancyCheckupModel>();
        }
    }
}
