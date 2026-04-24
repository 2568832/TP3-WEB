namespace TP2.Models
{
    public class Compagnie
    {
        public int CompagnieID { get; set; }
        public List<Carte_Graphique> Cartes_Graphiques { get; set;}
        public string imgURL { get; set; }
        public string Nom {  get; set; }

        public string Description { get; set; }

        
    }
}
