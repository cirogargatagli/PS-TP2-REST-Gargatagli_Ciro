using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP2.REST.Domain.Entities
{
    public class Alquiler
    {
        public int AlquilerId { get; set; }

        [Required]
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }


        [Required]
        [Column(TypeName = "varchar(50)")]
        public string ISBN { get; set; }
        [ForeignKey("ISBN")]
        public Libro Libro { get; set; }

        [Required]
        public int EstadoID { get; set; }
        public EstadoAlquiler Estado { get; set; }

        public DateTime? FechaAlquiler { get; set; }
        public DateTime? FechaReserva { get; set; }
        public DateTime? FechaDevolucion { get; set; }
    }
}