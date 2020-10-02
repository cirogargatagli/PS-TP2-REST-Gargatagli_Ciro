using System;

namespace TP2.REST.Domain.DTO
{
    public class AlquilerDTO
    {
        public int AlquilerId { get; set; }

        public int ClienteID { get; set; }

        public string ISBN { get; set; }
       

        public DateTime? FechaAlquiler { get; set; }

        public DateTime? FechaReserva { get; set; }
    }
}