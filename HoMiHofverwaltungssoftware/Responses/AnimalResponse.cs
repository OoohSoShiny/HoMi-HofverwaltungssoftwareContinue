using HoMiHofverwaltungssoftware.Models;

namespace HoMiHofverwaltungssoftware.Responses
{
    public class AnimalResponse
    {
        public List<AnimalModel> Animals { get; set; }

        public AnimalResponse() 
        {
            Animals = new List<AnimalModel>();
        }
    }
}
