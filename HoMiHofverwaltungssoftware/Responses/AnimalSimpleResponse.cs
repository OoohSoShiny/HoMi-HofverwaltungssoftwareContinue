using HoMiHofverwaltungssoftware.Models;

namespace HoMiHofverwaltungssoftware.Responses
{
    public class AnimalSimpleResponse
    {
        public List<AnimalSimpleModel> animalsSimple { get; set; }
        public AnimalSimpleResponse() 
        {
            animalsSimple = new List<AnimalSimpleModel>();
        }
    }
}
