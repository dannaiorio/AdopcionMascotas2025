using System.Diagnostics;
using AdopcionMascotas.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdopcionMascotas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }

        //Agrego conexion al formulario de contacto
        public IActionResult FormContacto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FormContacto(string nombre, string email, string telefono, string mensaje)
        {
            ViewBag.Mensaje = $"Gracias por contactarte, {nombre}. Te responderemos al {telefono} o por correo.";
            return View();
        }
       // agrego boton info
        public IActionResult Info()
        {
            return View();
        }

        public IActionResult Dona()
        {
            return View();
        }

    }
}
