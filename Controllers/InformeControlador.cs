using InformeTorneo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

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
            if (!torneo.ValidarDatos())
            {
                return RedirectToAction("Index");
            }
            using(TorneoContext context = new())
            {
                context.Torneos.Add(torneo);
                context.SaveChanges();
            }
            return View();
        }
        
        [HttpGet]
        public IActionResult CreacionDeTorneo()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AgregarEquipo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AgregarEquipo(Equipo equipo)
        {
            if (!equipo.ValidarDatos())
            {
                return RedirectToAction(nameof(CreacionDeTorneo));
            }
            using (TorneoContext context = new())
            {
                equipo.CalcularDatas();
                context.Equipos.Add(equipo);
                context.SaveChanges();
            }
            return RedirectToAction(nameof(CreacionDeTorneo));
        }

        [HttpPost]
        public IActionResult MostrarInforme()
        {
            Informe informe = new();

            using (TorneoContext context = new())
            {
                if (context.Torneos.First()==null)
                {

                }
                
                informe.torneo=context.Torneos.First();
                informe.equipos= context.Equipos.ToList();
                
                context.Informes.Add(informe);
                context.SaveChanges();
            }
            return View(informe);
        }


        [HttpGet]
        public IActionResult EditarDato(String nombre)
        {
            using (TorneoContext context = new())
            {
                Equipo? equipoEditado = context.Equipos.Find(nombre);
                if(equipoEditado != null)
                {
                    return View(equipoEditado);
                }
                else
                {
                    return RedirectToAction(nameof(MostrarInforme));
                }
            }
        }
        [HttpPost]
        public IActionResult EditarDato(Equipo equipoEditado)
        {
            if (!equipoEditado.ValidarDatos())
            {
                return RedirectToAction(nameof(EditarDato));
            }
            Informe informe = new();
            using (TorneoContext context = new())
            {
                context.Equipos.Update(equipoEditado);
                informe.equipos = context.Equipos.ToList();
                equipoEditado.CalcularDatas();
                context.SaveChanges();
            }
            return RedirectToAction(nameof(MostrarInforme));
        }

    }
}
