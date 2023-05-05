using HoMiHofverwaltungssoftware.Models;

namespace HoMiHofverwaltungssoftware.Responses
{
    public class AnimalCompleteResponse
    {
        public List<AnimalCompleteModel> AnimalCompleteModels { get; set; }  
        
        public AnimalCompleteResponse() 
        {
            AnimalCompleteModels = new List<AnimalCompleteModel>();
        }
    }
}
