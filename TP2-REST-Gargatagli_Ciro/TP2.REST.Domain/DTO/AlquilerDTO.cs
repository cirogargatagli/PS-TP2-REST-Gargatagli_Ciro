namespace TP2.REST.Domain.DTO
{
    public class AlquilerDTO
    {
        public int ClienteID { get; set; }

        public string ISBN { get; set; }

        public string FechaAlquiler { get; set; }

        public string FechaReserva { get; set; }
    }
}