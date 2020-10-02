using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP2.REST.Domain.Entities
{
    public class Cliente
    {
        private int clienteId;
        private string dni;
        private string nombre;
        private string apellido;
        private string email;

        public int ClienteId { get => clienteId; set => clienteId = value; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string DNI { get => dni; set => dni = value; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Nombre { get => nombre; set => nombre = value; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Apellido { get => apellido; set => apellido = value; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Email { get => email; set => email = value; }
    }
}
