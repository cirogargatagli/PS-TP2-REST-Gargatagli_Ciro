
namespace TP2.REST.Domain.DTO
{
    public class ResponseGetLibro
    {
        public string ISBN { get; set; }

        public string Titulo { get; set; }

        public string Autor { get; set; }

        public string Editorial { get; set; }

        public string Edicion { get; set; }

        public int Stock { get; set; }

        public string Imagen { get; set; }
    }
}