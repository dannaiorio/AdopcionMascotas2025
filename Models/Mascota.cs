using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace AdopcionMascotas.Models
{
    public class Mascota
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public EspecieMascota Especie { get; set; }
        public EstadoMascota Estado { get; set; }
        public int Edad { get; set; }
        public required string Descripcion { get; set; }

        public string? ImagenUrl { get; set; }

        [NotMapped]
        [ValidateNever]
        public IFormFile? ImagenFile { get; set; }
    }
}

