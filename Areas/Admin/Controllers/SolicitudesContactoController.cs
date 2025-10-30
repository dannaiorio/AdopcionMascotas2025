using AdopcionMascotas.Data;
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
    }
}
