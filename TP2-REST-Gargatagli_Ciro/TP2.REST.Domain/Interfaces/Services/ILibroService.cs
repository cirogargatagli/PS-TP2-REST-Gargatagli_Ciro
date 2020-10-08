using System.Collections.Generic;
using TP2.REST.Domain.DTO;

namespace TP2.REST.Domain.Interfaces.Services
{
    public interface ILibroService
    {
        List<ResponseGetLibro> GetLibros(bool? stock, string autor, string titulo);
    }
}
