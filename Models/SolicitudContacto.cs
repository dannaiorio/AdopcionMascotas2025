using System.ComponentModel.DataAnnotations;

namespace AdopcionMascotas.Models
{
    public class SolicitudContacto
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string Telefono { get; set; }

        [Required]
        public string Mensaje { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
