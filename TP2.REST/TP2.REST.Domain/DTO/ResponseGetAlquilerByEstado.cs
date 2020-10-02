

namespace TP2.REST.Domain.DTO
{
    public class ResponseGetAlquilerByEstadoId
    {
        public int AlquilerId { get; set; }

        public string ISBN { get; set; }

        public int EstadoID { get; set; }

        public string EstadoAlquilerDescripcion { get; set; }

        public string LibroTitulo { get; set; }

        public string LibroAutor { get; set; }

        public string LibroEditorial { get; set; }

        public string LibroEdicion { get; set; }

        public int LibroStock { get; set; }
    }
}