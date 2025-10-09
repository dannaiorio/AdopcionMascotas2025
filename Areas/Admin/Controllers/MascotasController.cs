using Microsoft.AspNetCore.Mvc;
using AdopcionMascotas.Data;
using AdopcionMascotas.Models;
using AdopcionMascotas.Attributes;

namespace AdopcionMascotas.Areas.Admin.Controllers
{
    [Area("Admin")]
    //Requiere autenticacion de admin para acceder a las acciones del controlador
    [AdminAuthRequired]
    public class MascotasController : Controller
    {
        private readonly AppDbContext _context;

        public MascotasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Mascotas
        public IActionResult Index()
        {
            var mascotas = _context.Mascotas.ToList();
            return View(mascotas);
        }

        // GET: Admin/Mascotas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Mascotas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mascota);
                _context.SaveChanges();

               
                TempData["SuccessMessage"] = "Mascota creada con éxito 🐾";

                return RedirectToAction(nameof(Index));
            }
            return View(mascota);
        }


        // GET: Admin/Mascotas/Edit/5
        public IActionResult Edit(int id)
        {
            var mascota = _context.Mascotas.FirstOrDefault(m => m.Id == id);
            if (mascota == null)
            {
                return NotFound();
            }
            return View(mascota);
        }

        // POST: Admin/Mascotas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Mascota mascota, IFormFile? imagenArchivo)
        {
            if (id != mascota.Id)
            {
                TempData["ErrorMessage"] = "La mascota no existe.";
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                if (imagenArchivo != null && imagenArchivo.Length > 0)
                {
                    var fileName = Path.GetFileName(imagenArchivo.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imagenArchivo.CopyTo(stream);
                    }

                    mascota.Imagen = "/images/" + fileName;
                }

                _context.Update(mascota);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Mascota editada correctamente ✏️";

                return RedirectToAction(nameof(Index));
            }
            return View(mascota);
        }

        // GET: Admin/Mascotas/Delete/5
        public IActionResult Delete(int id)
        {
            var mascota = _context.Mascotas.FirstOrDefault(m => m.Id == id);
            if (mascota == null)
            {
                TempData["ErrorMessage"] = "La mascota no fue encontrada.";
                return RedirectToAction(nameof(Index));
            }
            return View(mascota);
        }


        // POST: Admin/Mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var mascota = _context.Mascotas.FirstOrDefault(m => m.Id == id);
            if (mascota == null)
            {
                TempData["ErrorMessage"] = "La mascota no fue encontrada.";
                return RedirectToAction(nameof(Index));
            }

            _context.Mascotas.Remove(mascota);
            _context.SaveChanges();

            TempData["SuccessMessage"] = $"Mascota '{mascota.Nombre}' eliminada 🗑️";

            return RedirectToAction(nameof(Index));
        }





    }
}

