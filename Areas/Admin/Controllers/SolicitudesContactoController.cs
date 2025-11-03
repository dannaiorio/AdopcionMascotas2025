using AdopcionMascotas.Data;
using AdopcionMascotas.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdopcionMascotas.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SolicitudesContactoController : Controller
    {
        private readonly AppDbContext _context;

        public SolicitudesContactoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var solicitudes = _context.SolicitudesContacto
                .OrderByDescending(s => s.Fecha)
                .ToList();
            return View(solicitudes);
        }

        [HttpPost]
        public IActionResult CambiarEstado(int id)
        {
            var solicitud = _context.SolicitudesContacto.FirstOrDefault(s => s.Id == id);

            if (solicitud != null)
            {
                solicitud.Estado = solicitud.Estado == EstadoMensaje.Pendiente
                    ? EstadoMensaje.Resuelto
                    : EstadoMensaje.Pendiente;

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
