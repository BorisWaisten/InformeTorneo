﻿using InformeTorneo.Models;
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
                context.SaveChanges();
            }
            return View();
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
                informe.torneo=context.Torneos.First();
                informe.equipos= context.Equipos.ToList();
                context.Informes.Add(informe);
                context.SaveChanges();
            }
            return View(informe);
        }

    }
}
