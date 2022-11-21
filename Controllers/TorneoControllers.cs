using Microsoft.AspNetCore.Mvc;

namespace InformeTorneo.Controllers
{
    public class TorneoControllers : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
