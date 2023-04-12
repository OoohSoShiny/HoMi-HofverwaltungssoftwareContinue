namespace HoMiHofverwaltungssoftware.Responses
{
    public class RutCheckResponse
    {
        public List<RutCheckResponse> RutChecks { get; set; }

        public RutCheckResponse() 
        {
            RutChecks = new List<RutCheckResponse>();
        }
    }
}
