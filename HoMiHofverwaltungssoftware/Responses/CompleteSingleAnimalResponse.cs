using HoMiHofverwaltungssoftware.Models;

namespace HoMiHofverwaltungssoftware.Responses
{
    public class CompleteSingleAnimalResponse
    {
        public List<CompleteSingleAnimalModel> CompleteSingleAnimal;
        
        public CompleteSingleAnimalResponse()
        {
            CompleteSingleAnimal = new List<CompleteSingleAnimalModel>();
        }
    }
}
