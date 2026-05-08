using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using TP2.Extensions;
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
            var enfantIDs = HttpContext.Session.Get<List<int>>("enfantIDs");
            if (enfantIDs == null)
            {
                enfantIDs= new List<int>();
            }

            var enfantsDeLaBD = _baseDeDonnees.Carte_Graphiques.Where(e => enfantIDs.Contains(e.ID)).ToList();

            return View(enfantsDeLaBD);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AjouterUnEnfant(int id)
        {
              

                List<int> ID = HttpContext.Session.Get<List<int>>("enfantIDs");

                if (ID == null)
                {
                    ID = new List<int>();
                }

                bool test = _baseDeDonnees.Carte_Graphiques.Any(c => c.ID == id);
                if (!test)
                {
                    ID.Add(id);

                    HttpContext.Session.Set("enfantIDs", ID);


                    RedirectToAction("Index", "Favoris", _baseDeDonnees.Carte_Graphiques);
                return View("Index");

                 }
                 else
                {
                    
                    return View("Index");

                }
            

        }

        

        //public ActionResult Create(Crewmate collection)
        //{
        //    if (!ModelState.IsValid)
        //        return View(collection);

        //    // Vérifie si la couleur existe déjà
        //    bool colorUsed = _db.Crewmates.Any(p => p.Color == collection.Color);

        //    if (colorUsed)
        //    {
        //        // Ajoute un message d’erreur pour l’utilisateur
        //        ModelState.AddModelError("Color", "Cette couleur est déjà utilisée.");
        //        return View(collection);
        //    }

        //    // Si la couleur n'est pas utilisée, on ajoute
        //    _db.Crewmates.Add(collection);

        //    return RedirectToAction(nameof(Index));
        //}

        public IActionResult SupprimerUnEnfant(int id)
        {
            return View();
        }

    }
}
