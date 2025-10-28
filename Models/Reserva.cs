using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MesaListo.Models
{
    public class Reserva
    {
        public int ReservaID { get; set; }

        [Required]
        public DateTime FechaReserva { get; set; }

        [Required]
        public TimeOnly HoraInicio { get; set; }

        [Required]
        public TimeOnly HoraFin { get; set; }

        [Required]
        public Boolean Estado { get; set; }

        // Llave foranea a la Mesa
        [Required]
        public int MesaID { get; set; }
        public Mesa Mesa { get; set; } = null!;

        // Llave foranea al Usuario Cliente
        [Required]
        public string ClienteID { get; set; } = string.Empty;
        public ApplicationUser Cliente { get; set; } = null!;


        //Relacion 1 a 1 con la Reseña
        public Resenia? Resenia { get; set; }

    }
}
