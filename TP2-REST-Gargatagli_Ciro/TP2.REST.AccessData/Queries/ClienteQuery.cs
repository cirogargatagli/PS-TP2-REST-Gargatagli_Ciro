﻿using SqlKata.Compilers;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TP2.REST.Domain.DTO;
using TP2.REST.Domain.Interfaces.Queries;

namespace TP2.REST.AccessData.Queries
{
    public class ClienteQuery : IClienteQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKatacompiler;

        public ClienteQuery(IDbConnection connection, Compiler sqlKatacompiler)
        {
            this.connection = connection;
            this.sqlKatacompiler = sqlKatacompiler;
        }

        public List<ResponseGetCliente> GetAllClientes(string nombre, string apellido, string dni)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            var query = db.Query("Cliente")
                .When(!string.IsNullOrWhiteSpace(nombre), q => q.WhereLike("Nombre", $"%{nombre}%"))
                .When(!string.IsNullOrWhiteSpace(apellido), q => q.WhereLike("Apellido", $"%{apellido}%"))
                .When(!string.IsNullOrWhiteSpace(dni), q => q.WhereLike("DNI", $"%{dni}%"));

            var result = query.Get<ResponseGetCliente>();
            return result.ToList();
        }

        public bool ExisteDNI(string dni)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            var cliente = db.Query("Cliente")
                .Where("DNI", dni)
                .FirstOrDefault();
            return (cliente == null ? false : true);
        }
    }
}
