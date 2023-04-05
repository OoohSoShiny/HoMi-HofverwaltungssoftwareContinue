namespace HoMiHofverwaltungssoftware.Models
{
    public class PastureTimes
    {
        public int Id { get; set; }
        public int PastureId { get; set; }
        public int GroupId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set;}
    }
}
