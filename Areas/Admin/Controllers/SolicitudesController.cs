using AdopcionMascotas.Data;
using AdopcionMascotas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdopcionMascotas.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SolicitudesController : Controller
    {
        private readonly AppDbContext _context;

        public SolicitudesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Solicitudes
        public IActionResult Index()
        {
            var solicitudes = _context.Solicitudes
                .Include(s => s.Mascota)
                .ToList();

            return View(solicitudes);
        }

        [HttpPost]
        public IActionResult CambiarEstado(int id)
        {
            var solicitud = _context.Solicitudes
                .FirstOrDefault(s => s.Id == id);

            if (solicitud != null)
            {
                solicitud.Estado = solicitud.Estado == EstadoSolicitud.Pendiente
                    ? EstadoSolicitud.Resuelta
                    : EstadoSolicitud.Pendiente;

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
