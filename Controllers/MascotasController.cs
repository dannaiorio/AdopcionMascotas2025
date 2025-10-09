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

        public IActionResult Index()
        {
            var mascotas = _context.Mascotas.ToList();
            return View(mascotas);
        }

        public IActionResult Gatos()
        {
            var gatos = _context.Mascotas.Where(m => m.Especie == EspecieMascota.Gato).ToList();
            ViewData["Title"] = "Gatos en Adopción";
            ViewData["TipoMascota"] = "Gatos";
            return View("MascotasPorEspecie", gatos);
        }

        
        public IActionResult Perros()
        {
            var perros = _context.Mascotas.Where(m => m.Especie == EspecieMascota.Perro).ToList();
            ViewData["Title"] = "Perros en Adopción";
            ViewData["TipoMascota"] = "Perros";
            return View("MascotasPorEspecie", perros);
        }
        public IActionResult Detalle(int id)
        {
            var mascota = _context.Mascotas.FirstOrDefault(m => m.Id == id);
            if (mascota == null)
            {
                return NotFound();
            }
            return View(mascota);
        }

        public IActionResult Crear()
        {
            return View();
        }

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
