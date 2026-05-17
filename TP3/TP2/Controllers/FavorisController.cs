using Microsoft.AspNetCore.Mvc;
using TP2.Extensions;
using TP2.Models;

namespace TP2.Controllers
{
    public class FavorisController : Controller
    {
        private BaseDeDonnees _baseDeDonnees { get; set; }

        public FavorisController(BaseDeDonnees baseDeDonnees)
        {
            _baseDeDonnees = baseDeDonnees;
        }

        [Route("/Favoris/Index")]
        public IActionResult Index()
        {
            var enfantIDs = HttpContext.Session.Get<List<int>>("enfantIDs");
            if (enfantIDs == null)
                enfantIDs = new List<int>();

            var enfantsDeLaBD = _baseDeDonnees.Carte_Graphiques
                .Where(e => enfantIDs.Contains(e.ID))
                .ToList();

            return View(enfantsDeLaBD);
        }

        [HttpPost]
        public IActionResult AjouterUnEnfant(int id)
        {
            var ids = HttpContext.Session.Get<List<int>>("enfantIDs") ?? new List<int>();

            if (!ids.Contains(id))
                ids.Add(id);

            HttpContext.Session.Set("enfantIDs", ids);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SupprimerUnEnfant(int id)
        {
            var ids = HttpContext.Session.Get<List<int>>("enfantIDs") ?? new List<int>();

            ids.Remove(id);

            HttpContext.Session.Set("enfantIDs", ids);

            return RedirectToAction("Index");
        }
    }
}