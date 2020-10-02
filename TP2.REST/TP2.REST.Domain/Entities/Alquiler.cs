using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP2.REST.Domain.Entities
{
    public class Alquiler
    {
        private int alquilerId;
        private Cliente cliente;
        private Libro libro;
        private EstadoAlquiler estado;
        private DateTime? fechaAlquiler = null;
        private DateTime? fechaReserva = null;
        private DateTime? fechaDevolucion = null;

        public int AlquilerId { get => alquilerId; set => alquilerId = value; }

        [Required]
        public int ClienteID { get; set; }
        public Cliente Cliente { get => cliente; set => cliente = value; }

        
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string ISBN { get; set; }
        [ForeignKey("ISBN")]
        public Libro Libro { get => libro; set => libro = value; }

        [Required]
        public int EstadoID { get; set; }
        public EstadoAlquiler Estado { get => estado; set => estado = value; }

        public DateTime? FechaAlquiler { get => fechaAlquiler; set => fechaAlquiler = value; }
        public DateTime? FechaReserva { get => fechaReserva; set => fechaReserva = value; } 
        public DateTime? FechaDevolucion { get => fechaDevolucion; set => fechaDevolucion = value; }       
    }
}