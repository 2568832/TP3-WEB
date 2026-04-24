namespace TP2.Models
{
    public class Carte_Graphique
    {
        public int ID { get; set; }
        public string Nom { get; set; }

        public bool Vedette { get; set; }

        public string Model { get; set; }
        public double Prix { get; set; }
        public string PerformanceAI { get; set; }
        public string ConsomationMaxEn_Watt {  get; set; }
        public string Mémoire_vidéo { get; set; }
        public string ResolutionPriorise { get; set; }
        public string InfoIA { get; set; }
        public string Description { get; set; }
        public Compagnie compagnie { get; set; }
        public int CompagnieID { get; set; }

        public string imgURL { get; set; }

        

    }
}
