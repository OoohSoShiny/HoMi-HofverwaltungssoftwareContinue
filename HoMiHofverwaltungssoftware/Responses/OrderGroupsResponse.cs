using HoMiHofverwaltungssoftware.Models;

namespace HoMiHofverwaltungssoftware.Responses
{
    public class OrderGroupsResponse
    {
        public List<OrderGroupsModel> OrderGroups { get; set; }

        public OrderGroupsResponse() 
        {
            OrderGroups = new List<OrderGroupsModel>();
        }
    }
}
