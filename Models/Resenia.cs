using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MesaListo.Models
{
    public class Resenia
    {
        public int ReseniaID { get; set; }

        [Required, Range(1, 10)]
        public int Calificacion { get; set; }

        [Required, StringLength(500)]
        public String Comentario { get; set; } = String.Empty;

        [Required]
        public DateTime FechaResenia { get; set; } = DateTime.Now;

        // Llave foranea a la Reserva
        [Required]
        public int ReservaID { get; set; }
        public Reserva Reserva { get; set; } = null!;

        // Llave foranea al Usuario Cliente
        [Required]
        public string ClienteID { get; set; } = string.Empty;
        public ApplicationUser Cliente { get; set; } = null!;


    }
}
