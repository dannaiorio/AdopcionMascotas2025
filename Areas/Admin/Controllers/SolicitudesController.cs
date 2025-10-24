using Microsoft.AspNetCore.Mvc;
using AdopcionMascotas.Data;
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
    }
}
