using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TP2.REST.Domain.DTO;
using TP2.REST.Domain.Entities;
using TP2.REST.Domain.Queries;

namespace TP2.REST.AccessData.Queries
{
    public class AlquilerQuery : IAlquilerQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKatacompiler;

        public AlquilerQuery(IDbConnection connection, Compiler sqlKatacompiler)
        {
            this.connection = connection;
            this.sqlKatacompiler = sqlKatacompiler;
        }

        public List<ResponseGetAlquilerByEstadoId> GetByEstadoID(int estadoid)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            var alquileres_reservas = db.Query("Alquiler")
                .Select("Alquiler.AlquilerID",
                "Alquiler.ISBN",
                "Alquiler.EstadoID",
                "Libro.Titulo AS LibroTitulo",
                "Libro.Autor AS LibroAutor",
                "Libro.Editorial AS LibroEditorial",
                "Libro.Edicion AS LibroEdicion",
                "Libro.Stock AS LibroStock",
                "EstadoAlquiler.Descripcion AS EstadoAlquilerDescripcion"
                )
                .Join("Libro", "Libro.ISBN", "Alquiler.ISBN")
                .Join("EstadoAlquiler", "EstadoAlquiler.EstadoAlquilerID", "Alquiler.EstadoID")
                .When(!(estadoid == 0), q => q.WhereLike("EstadoID", $"%{estadoid}%"))
                .Get<ResponseGetAlquilerByEstadoId>()
                .ToList();
            return alquileres_reservas;
        }

        public List<ResponseGetLibro> GetLibroByCliente(int idcliente)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            var libro = db.Query("Alquiler")
                .Select(
                "Libro.ISBN",
                "Libro.Titulo",
                "Libro.Autor",
                "Libro.Editorial",
                "Libro.Edicion",
                "Libro.Stock"
                )
                .Join("Libro", "Libro.ISBN", "Alquiler.ISBN")
                .Get<ResponseGetLibro>()
                .ToList();
            return libro;
        }

        public GenericModifyResponseDTO ModifyReserva(int clienteid, string isbn)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            db.Query("Alquiler")
                .Where(new
                {
                    ClienteID = clienteid,
                    ISBN = isbn
                })
                .Update(new
                {
                    EstadoID = 2,
                    FechaAlquiler = DateTime.Now,
                    FechaDevolucion = DateTime.Now.AddDays(7)
                });

            var alquiler = db.Query("Alquiler")
                .Where(new
                {
                    ClienteID = clienteid,
                    ISBN = isbn
                })
                .Get<Alquiler>()
                .FirstOrDefault();

            return new GenericModifyResponseDTO { Entity = "Alquiler", Id = alquiler.AlquilerId.ToString(), Estado = "Modificado" };
        }

        public void ModifyStock(string isbn)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);

            //Consultamos cuál es el stock actual del libro
            int query = db.Query("Libro")
                .Select("Stock")
                .Where("ISBN", isbn)
                .Get<int>()
                .FirstOrDefault();

            //Decrementamos el stock
            db.Query("Libro")
                .Where("ISBN", isbn)
                .Update(new { Stock = query - 1 });
        }
    }
}