
using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel.DataAnnotations;

namespace AdopcionMascotas.Models
{
    public class SolicitudAdopcion
    {
        public int Id { get; set; }

        public int MascotaId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string NombreApellido { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La ciudad es obligatoria")]
        public string Ciudad { get; set; }

        public string DireccionAprox { get; set; }

        [Required(ErrorMessage = "Debe indicar el tipo de vivienda")]
        public string TipoVivienda { get; set; }

        [Required(ErrorMessage = "Debe indicar si tiene patio o balcón")]
        public string EspacioExterior { get; set; }

        [Required(ErrorMessage = "Debe indicar si tiene otras mascotas")]
        public string OtrasMascotas { get; set; }

        [Required(ErrorMessage = "Debe indicar su motivo de adopción")]
        public string Motivo { get; set; }

        [Required(ErrorMessage = "Debe responder si puede cuidar al animal diariamente")]
        public string CuidadoDiario { get; set; }

        [Required(ErrorMessage = "Debe responder si acepta seguimiento")]
        public string Seguimiento { get; set; }

        public string Comentario { get; set; }

        // Relación con Mascota (para poder acceder al nombre, especie, etc.)
        public Mascota? Mascota { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaSolicitud { get; set; } = DateTime.Now;

        public EstadoSolicitud Estado { get; set; } = EstadoSolicitud.Pendiente;

    }
}
