
namespace TP2.REST.Domain.DTO
{
    public class ResponseGetCliente
    {
        public int ClienteId { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string DNI { get; set; }

        public string Email { get; set; }
    }
}