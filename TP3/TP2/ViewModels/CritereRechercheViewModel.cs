namespace TP2.ViewModels
{
    public class CritereRechercheViewModel
    {
        public string? MotsCles { get; set; }

        public int? Min { get; set; }
        public int? Max { get; set; }

        public string? Vedette { get; set; } // "oui", "non", "peuimporte"

        public bool CompagnieNVIDIA { get; set; }
        public bool CompagnieIntel { get; set; }
        public bool CompagnieAMD { get; set; }
    }
}