using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP2.REST.Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string DNI { get; set; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Apellido { get; set; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Email { get; set; }
    }
}
