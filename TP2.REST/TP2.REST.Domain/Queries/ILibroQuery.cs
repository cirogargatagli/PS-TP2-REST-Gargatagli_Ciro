using System.Collections.Generic;
using TP2.REST.Domain.DTO;

namespace TP2.REST.Domain.Queries
{
    public interface ILibroQuery
    {
        List<ResponseGetLibro> GetLibros(bool stock, string autor, string titulo);
    }
}
