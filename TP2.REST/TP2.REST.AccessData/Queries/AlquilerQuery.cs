using SqlKata.Compilers;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TP2.REST.Domain.DTO;
using TP2.REST.Domain.Entities;
using TP2.REST.Domain.Interfaces.Queries;

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

        public List<ResponseGetLibrosByCliente> GetLibroByCliente(int idcliente)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            var libro = db.Query("Alquiler")
                .Select(
                "Libro.ISBN",
                "Libro.Titulo",
                "Libro.Autor",
                "Libro.Editorial",
                "Libro.Edicion"
                )
                .Join("Libro", "Libro.ISBN", "Alquiler.ISBN")
                .Where("Alquiler.ClienteId", idcliente)
                .Get<ResponseGetLibrosByCliente>()
                .ToList();
            return libro;
        }

        public List<Alquiler> GetReserva(int clienteid, string isbn)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            List<Alquiler> alquileres = db.Query("Alquiler")
                .Where(new
                {
                    ClienteID = clienteid,
                    ISBN = isbn,
                    EstadoId = 1
                })
                .Get<Alquiler>()
                .ToList();

            return alquileres;
        }

        public Libro GetLibro(string isbn)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            Libro libro = db.Query("Libro")
                .Where("ISBN", isbn)
                .Get<Libro>()
                .FirstOrDefault();

            return libro;
        }

        public bool ExisteCliente(int clienteID)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            bool existeCliente = db.Query("Cliente")
                .Where("ClienteId", clienteID)
                .Get<bool>()
                .FirstOrDefault();

            return existeCliente;
        }

        public bool ExisteLibro(string iSBN)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            var libro = db.Query("Libro")
                .Where("ISBN", iSBN)
                .Get<Libro>()
                .FirstOrDefault();

            return (libro != null);
        }

        public bool ExisteStock(string iSBN)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            var libro = db.Query("Libro")
                .Where("ISBN", iSBN)
                .Get<Libro>()
                .FirstOrDefault();

            return (libro.Stock > 0);
        }

        public bool ExisteReservaDelCliente(int clienteID)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            bool existeReserva = db.Query("Alquiler")
                .Where("ClienteId", clienteID)
                .Get<bool>()
                .FirstOrDefault();

            return existeReserva;
        }

        public bool ExisteReservaDelLibro(string isbn)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            bool existeReserva = db.Query("Alquiler")
                .Where("ISBN", isbn)
                .Get<bool>()
                .FirstOrDefault();

            return existeReserva;
        }


    }
}