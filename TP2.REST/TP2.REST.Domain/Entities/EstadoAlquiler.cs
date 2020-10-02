using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP2.REST.Domain.Entities
{
    public class EstadoAlquiler
    {
        private int estadoAlquilerId;
        private string descripcion;

        public int EstadoAlquilerId { get => estadoAlquilerId; set => estadoAlquilerId = value; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
