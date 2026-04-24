using System.Linq;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP2.Models;


namespace TP2.Controllers
{
    public class HomeController : Controller
    {
        private BaseDeDonnees _baseDeDonnees { get; set; }

        public HomeController(BaseDeDonnees baseDeDonnees)
        {
            _baseDeDonnees = baseDeDonnees;
        }

        public IActionResult Index()
        {
            return View(_baseDeDonnees.Compagnies.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
