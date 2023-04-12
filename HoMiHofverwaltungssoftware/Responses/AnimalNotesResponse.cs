using HoMiHofverwaltungssoftware.Models;

namespace HoMiHofverwaltungssoftware.Responses
{
    public class AnimalNotesResponse
    {
        public List<AnimalNotesModel> AnimalNotes { get; set; }

        public AnimalNotesResponse() 
        { 
            AnimalNotes = new List<AnimalNotesModel>();
        }
    }
}
