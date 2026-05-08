using Microsoft.AspNetCore.Mvc;

namespace TP2.Controllers
{
    public class FavorisController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
