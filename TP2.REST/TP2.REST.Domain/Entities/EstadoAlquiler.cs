using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP2.REST.Domain.Entities
{
    public class EstadoAlquiler
    {
        public int EstadoAlquilerId { get; set; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Descripcion { get; set; }
    }
}
