using InformeTorneo.Models;
using Microsoft.AspNetCore.Mvc;

namespace InformeTorneo.Controllers
{
    public class InformeControlador : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreacionDeTorneo(Torneo torneo)
        {
            using(TorneoContext context = new())
            {
                context.Torneos.Add(torneo);
                //context.SaveChanges();
            }
            return RedirectToAction(nameof(CreacionDeTorneo));
        }
        
        [HttpGet]
        public IActionResult CreacionDeTorneo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AgregarEquipo(Equipo equipo)
        {
            using (TorneoContext context = new())
            {
                
                context.Equipos.Add(equipo);
                //context.SaveChanges();
            }
            return RedirectToAction(nameof(CreacionDeTorneo));
        }

        [HttpPost]
        public IActionResult MostrarInforme()
        {
            using (TorneoContext context = new())
            {
            }
            return View();
        }

    }
}
