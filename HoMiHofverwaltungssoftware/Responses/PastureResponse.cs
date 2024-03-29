﻿using HoMiHofverwaltungssoftware.Models;

namespace HoMiHofverwaltungssoftware.Responses
{
    public class PastureResponse
    {
        public List<PastureModel> Pastures { get; set; }

        public PastureResponse() 
        {
            Pastures = new List<PastureModel>();
        }
    }
}
