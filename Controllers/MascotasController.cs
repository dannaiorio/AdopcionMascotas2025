using Microsoft.AspNetCore.Mvc;
using AdopcionMascotas.Data;
using AdopcionMascotas.Models;
using System.Linq;

namespace AdopcionMascotas.Controllers
{
    public class MascotasController : Controller
    {
        private readonly AppDbContext _context;

        public MascotasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Mascotas te muestra una lista con todas las mascotas cargadas.
        public IActionResult Index()
        {
            var mascotas = _context.Mascotas.ToList();
            return View(mascotas);
        }

        // GET: /Mascotas/Detalle/5 Esto es lo que se abre cuando hacés clic en "Ver" en la lista.
        public IActionResult Detalle(int id)
        {
            var mascota = _context.Mascotas.FirstOrDefault(m => m.Id == id);
            if (mascota == null)
            {
                return NotFound();
            }
            return View(mascota);
        }

        // GET: /Mascotas/Crear Muestra un formulario vacío (Crear.cshtml) para cargar una nueva mascota.
        public IActionResult Crear()
        {
            return View();
        }

        // POST: /Mascotas/Crear Esto es lo que hace que cuando vos agregues un nuevo registro en el formulario, se inserte en AdopcionMascotasDB → tabla Mascotas.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                _context.Mascotas.Add(mascota);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(mascota);
        }
    }
}
