using AdopcionMascotas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

using AdopcionMascotas.Data;


namespace AdopcionMascotas.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(AppDbContext context)
        {
            _context = context;
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
            if (ModelState.IsValid)
            {
                var solicitud = new SolicitudContacto
                {
                    Nombre = nombre,
                    Email = email,
                    Telefono = telefono,
                    Mensaje = mensaje
                };

                Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<SolicitudContacto> entityEntry = _context.SolicitudesContacto.Add(solicitud);
                _context.SaveChanges();

                ViewBag.Mensaje = $"Gracias por contactarte, {nombre}. Te responderemos al {telefono} o por correo.";
            }

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
