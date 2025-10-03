using Microsoft.EntityFrameworkCore;
using AdopcionMascotas.Models;

namespace AdopcionMascotas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Tablas
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<SolicitudAdopcion> Solicitudes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Mascota>().HasData(
                new Mascota
                {
                    Id = 1,
                    Nombre = "Firulais",
                    Especie = EspecieMascota.Perro,
                    Edad = 3,
                    Estado = EstadoMascota.Disponible,
                    Descripcion = "Perro juguetón y sociable",
                    Imagen = "/images/placeholder.jpg"
                },
                new Mascota
                {
                    Id = 2,
                    Nombre = "Luna",
                    Especie = EspecieMascota.Perro,
                    Edad = 5,
                    Estado = EstadoMascota.Disponible,
                    Descripcion = "Perra tranquila y cariñosa",
                    Imagen = "/images/placeholder.jpg"
                },
                new Mascota
                {
                    Id = 3,
                    Nombre = "Michi",
                    Especie = EspecieMascota.Gato,
                    Edad = 2,
                    Estado = EstadoMascota.Disponible,
                    Descripcion = "Gato curioso y activo",
                    Imagen = "/images/placeholder.jpg"
                },
                new Mascota
                {
                    Id = 4,
                    Nombre = "Nieve",
                    Especie = EspecieMascota.Gato,
                    Edad = 4,
                    Estado = EstadoMascota.EnProceso,
                    Descripcion = "Gata blanca muy mimosa",
                    Imagen = "/images/placeholder.jpg"
                }
            );
        }

    }
}