using HoMiHofverwaltungssoftware.Models;

namespace HoMiHofverwaltungssoftware.Responses
{
    public class OrderGroupsResponse
    {
        public List<OrderGroupsModel> Groups { get; set; }

        public OrderGroupsResponse() 
        {
            Groups = new List<OrderGroupsModel>();
        }
    }
}
