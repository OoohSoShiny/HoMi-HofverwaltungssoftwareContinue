namespace HoMiHofverwaltungssoftware.Responses
{
    public class PastureGroupConnectorResponse
    {
        public List<PastureGroupConnectorResponse> PastureGroupConnectors { get; set; }

        public PastureGroupConnectorResponse() 
        {
            PastureGroupConnectors = new List<PastureGroupConnectorResponse>();
        }
    }
}
