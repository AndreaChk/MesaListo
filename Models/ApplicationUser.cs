using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MesaListo.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Direccion { get; set; }

        [StringLength(15)]
        public string? Telefono { get; set; }

        // Relación con las mesas (si es rol Restaurante)
        public ICollection<Mesa>? Mesas { get; set; }

        // Relación con las reservas (si es rol Cliente)
        public ICollection<Reserva>? Reservas { get; set; }

        // Relación con las reseñas (si es rol Cliente)
        public ICollection<Resenia>? Resenias { get; set; }
    }
}
