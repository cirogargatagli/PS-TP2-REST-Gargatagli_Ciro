using System.Collections.Generic;
using TP2.REST.Domain.Commands;
using TP2.REST.Domain.DTO;
using TP2.REST.Domain.Queries;

namespace TP2.REST.Application.Services
{
    public interface ILibroService
    {
        List<ResponseGetLibro> GetLibros(bool? stock, string autor, string titulo);
    }

    public class LibroService : ILibroService
    {
        private readonly IGenericRepository libroRepository;
        private readonly ILibroQuery _query;

        public LibroService(IGenericRepository repository, ILibroQuery query)
        {
            libroRepository = repository;
            _query = query;
        }

        public List<ResponseGetLibro> GetLibros(bool? stock, string autor, string titulo)
        {
            return _query.GetLibros(stock, autor, titulo);
        }

    }
}
