using Microsoft.AspNetCore.Mvc;
using TP2.Models;
using TP2.ViewModels;


namespace TP2.ViewModels
{
    public class PageRechercheViewModel
    {
        //public IActionResult Recherche()
        //{
        //    var model = new PageRechercheViewModel();

        //}

        public CritereRechercheViewModel Criteres { get; set; }
        public List<Carte_Graphique> Resultat { get; set; }
    }



}

