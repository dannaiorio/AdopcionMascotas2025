using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdopcionMascotas.Data;
using AdopcionMascotas.Models;

namespace AdopcionMascotas.Controllers
{
    public class MascotaController : Controller
    {
        private readonly AppDbContext _context;

        public MascotaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Mascota
        public async Task<IActionResult> Index()
        {
            return RedirectToAction("EnAdopcion");
        }


        // GET: Mascota/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mascota == null)
            {
                return NotFound();
            }

            return View(mascota);
        }
        // GET: Mascota/EnAdopcion
        public async Task<IActionResult> EnAdopcion()
        {
            var mascotas = await _context.Mascotas
                .Where(m => m.Estado == EstadoMascota.Disponible || m.Estado == EstadoMascota.EnProceso)
                .ToListAsync();

            return View(mascotas);
        }

        // GET: Mascota/Adoptados
        public async Task<IActionResult> Adoptados()
        {
            var mascotas = await _context.Mascotas
                .Where(m => m.Estado == EstadoMascota.Adoptada)
                .ToListAsync();

            return View(mascotas);
        }

    }
}
