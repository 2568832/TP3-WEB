using Microsoft.AspNetCore.Mvc;
using TP2.Models;
using TP2.ViewModels;

namespace TP2.Controllers
{
    public class EnfantController : Controller
    {
        private BaseDeDonnees _baseDeDonnees { get; set; }

        public EnfantController(BaseDeDonnees baseDeDonnees) 
        { 
            _baseDeDonnees = baseDeDonnees;
        }
        [Route("/Enfant/favoris")]
        public IActionResult favoris()
        {
            return View(_baseDeDonnees.Carte_Graphiques.ToList());
        }

        [Route("/Enfant/Recherche")]

        public IActionResult Recherche(CritereRechercheViewModel criteres)
        {
            var model = new PageRechercheViewModel();
            model.Criteres = criteres;

            var objRechercher = _baseDeDonnees.Carte_Graphiques.AsQueryable(); // Convertisseur de IEnumerable a IQueryable 

            // Motclé
            if (criteres.MotsCles != null && criteres.MotsCles != "")
            {
               
                objRechercher = objRechercher.Where(c =>
                    c.Nom.ToLower().Contains(criteres.MotsCles.ToLower()) ||
                    c.Description.ToLower().Contains(criteres.MotsCles.ToLower())
                );
            }

            // Prix min
            if (criteres.Min.HasValue)
                objRechercher = objRechercher.Where(c => c.Prix >= criteres.Min.Value);

            // Prix max
            if (criteres.Max.HasValue) // quand il a la valeur, ne pas oublié comment l'utiliser
                objRechercher = objRechercher.Where(c => c.Prix <= criteres.Max.Value);

            // Vedette
            if (criteres.Vedette == "oui")
                objRechercher = objRechercher.Where(c => c.Vedette == true);

            if (criteres.Vedette == "non")
                objRechercher = objRechercher.Where(c => c.Vedette == false);

            // Compagnies
            var compagnies = new List<int>();
            if (criteres.CompagnieNVIDIA) compagnies.Add(1);
            if (criteres.CompagnieIntel) compagnies.Add(3);
            if (criteres.CompagnieAMD) compagnies.Add(2);

            if (compagnies.Count > 0)
                objRechercher = objRechercher.Where(c => compagnies.Contains(c.CompagnieID));

            model.Resultat = objRechercher.ToList();

            return View(model);
        }




        [Route("/Enfant/Detail/{id:int}")]
        [Route("/Enfant/{id:int}")]
        [Route("/{id:int}")]

        public IActionResult Detail(int id)
        {
            var objSelectionné = _baseDeDonnees.Carte_Graphiques.Where(p => p.ID == id).SingleOrDefault();
            if (objSelectionné == null)
            {
                return View("NonTrouve","Le numéro de la carte n'a pas été trouvé!");
            }
            else
            {
                return View(objSelectionné);

            }
        }


        [Route("/Enfant/Detail/{name}")]
        [Route("/Enfant/{name}")]
        [Route("/{name}")]
        public IActionResult Detail(string name)
        {
            var objSelectionné = _baseDeDonnees.Carte_Graphiques.Where(p => p.Nom == name).SingleOrDefault();
            if (objSelectionné == null)
            {
                return View("NonTrouve", "Le numéro de la carte n'a pas été trouvé!");
            }
            else
            {
                return View(objSelectionné);

            }
        }

    }
}
