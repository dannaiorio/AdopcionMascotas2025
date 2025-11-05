using Microsoft.EntityFrameworkCore;
using AdopcionMascotas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace AdopcionMascotas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<SolicitudAdopcion> Solicitudes { get; set; }
        public DbSet<SolicitudContacto> SolicitudesContacto { get; set; }

    }
}
