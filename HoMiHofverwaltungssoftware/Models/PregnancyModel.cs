﻿namespace HoMiHofverwaltungssoftware.Models
{
    public class PregnancyModel
    {
        public int Id { get; set; }
        public int Muttertier { get; set; }
        public int Vatertier { get; set; }
        public int Kalbtier { get; set; }
        public DateTime Deckungstag { get; set; }
    }
}
