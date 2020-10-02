using System.Collections.Generic;
using TP2.REST.Domain.Commands;
using TP2.REST.Domain.DTO;
using TP2.REST.Domain.Entities;
using TP2.REST.Domain.Queries;

namespace TP2.REST.Application.Services
{
    public interface ILibroService
    {
        public Libro CreateLibro(LibroDTO cliente);
        List<ResponseGetLibro> GetLibros(bool stock, string autor, string titulo);
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

        public Libro CreateLibro(LibroDTO libro)
        {
            var entity = new Libro
            {
                Titulo = libro.Titulo,
                Autor = libro.Autor,
                Editorial = libro.Editorial,
                Edicion = libro.Edicion,
                Stock = libro.Stock,
                Imagen = libro.Imagen
            };
            libroRepository.Add<Libro>(entity);
            return entity;
        }

        public List<ResponseGetLibro> GetLibros(bool stock, string autor, string titulo)
        {
            return _query.GetLibros(stock,autor,titulo);
        }

    }
}
