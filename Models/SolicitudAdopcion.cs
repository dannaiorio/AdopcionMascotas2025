namespace AdopcionMascotas.Models
{
    public class SolicitudAdopcion
    {
        public int Id { get; set; }
        public string NombreSolicitante { get; set; }
        public string Email { get; set; }
        public string Respuestas { get; set; }

        // Relación con la mascota
        public int MascotaId { get; set; }
        public Mascota Mascota { get; set; }
    }
}
