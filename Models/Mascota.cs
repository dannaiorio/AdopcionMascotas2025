using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace AdopcionMascotas.Models
{
    public class Mascota
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public EspecieMascota Especie { get; set; }
        public int Edad { get; set; }
        public EstadoMascota Estado { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }

        // 👇 Esta propiedad es solo para subir archivos desde el formulario
        [NotMapped]
        public IFormFile ImagenArchivo { get; set; }
    }
}
