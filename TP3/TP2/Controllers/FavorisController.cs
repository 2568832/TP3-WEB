using Microsoft.AspNetCore.Mvc;
using TP2.Models;


namespace TP2.Controllers
{
    public class FavorisController : Controller
    {
        private BaseDeDonnees _baseDeDonnees { get; set; }

        public FavorisController (BaseDeDonnees baseDeDonnees)
        {
            _baseDeDonnees = baseDeDonnees;
        }

        [Route("/Favoris/Index")]
        public IActionResult Index()
        {
            return View("Index", _baseDeDonnees.Carte_Graphiques.ToList());
        }
      

        public IActionResult AjouterUnEnfant(int id)
        {
            return View();
        }

        public IActionResult SupprimerUnEnfant(int id)
        {
            return View();
        }
    }
}
