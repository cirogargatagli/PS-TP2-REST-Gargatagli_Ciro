using SqlKata.Compilers;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TP2.REST.Domain.DTO;
using TP2.REST.Domain.Queries;

namespace TP2.REST.AccessData.Queries
{
    public class LibroQuery : ILibroQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKatacompiler;

        public LibroQuery(IDbConnection connection, Compiler sqlKatacompiler)
        {
            this.connection = connection;
            this.sqlKatacompiler = sqlKatacompiler;
        }

        public List<ResponseGetLibro> GetLibros(bool stock, string autor, string titulo)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            var query = db.Query("Libro")
                .When(!stock, q => q.Where("Stock", "=", 0))
                .When(!string.IsNullOrWhiteSpace(autor), q => q.WhereLike("Autor", $"%{autor}%"))
                .When(!string.IsNullOrWhiteSpace(titulo), q => q.WhereLike("Titulo", $"%{titulo}%"))
                .Get<ResponseGetLibro>();

            return query.ToList();
        }
    }
}