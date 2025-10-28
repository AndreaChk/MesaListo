using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MesaListo.Models
{
    public class Mesa
    {
        public int MesaID { get; set; }

        [Required, StringLength(50)]
        public String CodigoMesa { get; set; } = String.Empty;

        [Required, Range(1,100)]
        public int Capacidad { get; set; }


        // Llave foranea a Restaurante
        [Required]
        public string RestauranteID { get; set; } = string.Empty;
        public ApplicationUser Restaurante { get; set; } = null!;



        // Relacion 1 a muchos con las Reservas
        public ICollection<Reserva>? Reservas { get; set; }

    }
}
