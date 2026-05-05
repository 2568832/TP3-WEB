using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP2.Models;

namespace TP2.Controllers
{
    public class GestionEnfantController : Controller
    {
        private BaseDeDonnees _baseDeDonnees { get; set; }

        public GestionEnfantController(BaseDeDonnees baseDeDonnees)
        {
            _baseDeDonnees = baseDeDonnees;
        }

        // GET: GestionEnfantController/Delete/5
        

        public ActionResult Delete(int id)
        {
            try
            {
                var item = _baseDeDonnees.Carte_Graphiques.Where(c => c.ID == id).SingleOrDefault();

                return View(item);
            }
            catch
            {
                return View("NonTrouve");
            }
            
        }

        // POST: GestionEnfantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                

                var carte = _baseDeDonnees.Carte_Graphiques.Where(c => c.ID == id).Single();
                _baseDeDonnees.Carte_Graphiques.Remove(carte);
                _baseDeDonnees.Compagnies[carte.CompagnieID].Cartes_Graphiques.Remove(carte);


                return RedirectToAction("Index","Home");

            }
            catch
            {
                return View();
            }
        }
    }
}
