using AdopcionMascotas.Models;
using Microsoft.AspNetCore.Mvc;
using AdopcionMascotas.Data;

namespace AdopcionMascotas.Controllers
{
    public class SolicitudesController : Controller
    {
        private readonly AppDbContext _context;

        public SolicitudesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Formulario(int idMascota)
        {
            var mascota = _context.Mascotas.FirstOrDefault(m => m.Id == idMascota);
            if (mascota == null) return NotFound();

            ViewBag.Mascota = mascota;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EnviarFormulario(SolicitudAdopcion solicitud)
        {
            if (ModelState.IsValid)
                solicitud.Comentario ??= string.Empty;
            {
                _context.Solicitudes.Add(solicitud);
                _context.SaveChanges();

                // Redirige a la página de agradecimiento
                return RedirectToAction("Gracias");
            }

            // Si hay error de validación, vuelve a mostrar el formulario
            var mascota = _context.Mascotas.FirstOrDefault(m => m.Id == solicitud.MascotaId);
            ViewBag.Mascota = mascota;
            return View("Formulario", solicitud);
        }



        public IActionResult Gracias()
        {
            return View();
        }
    }
}
