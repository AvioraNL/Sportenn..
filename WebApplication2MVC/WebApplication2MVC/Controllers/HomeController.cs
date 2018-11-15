using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2MVC.Models;

namespace WebApplication2MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }


        [HttpGet]
        public string NaampjeKijken(string voornaam)
        {
            List<string> namen = new List<string> {"Alan","Jeff","Yunus","Alan","Danny" };

            int count = 0;
            foreach (var naampje in namen)

            {
                if(voornaam == naampje)
                {
                    count++;
                } 

            }

            return "De naam " + voornaam + " komt " + count + "x voor in de lijst.";

        }

        [HttpGet]
        public string EmailKijken(int id)
        {
            List<Persoon> namen = new List<Persoon> {new Persoon("Achie","achie@live.nl"), new Persoon("Alan", "alan@live.nl"), new Persoon("Yunus", "yunus@live.nl"), new Persoon("Swijnhunt", "Swijnhunt@live.nl") };
            if(id+1 > namen.Count)
            {
                return string.Format("Helaas bestaat het getal {0} niet in onze database gelieve een andere getal op te geven",id);
            } else
            {
                return string.Format("Getal {0} levert naam: {1} en als email {2} op.", id, namen.ElementAt(id).Voornaam, namen.ElementAt(id).Email);
            }

        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
