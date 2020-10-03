using System.Collections.Generic;
using TP2.REST.Domain.DTO;

namespace TP2.REST.Domain.Queries
{
    public interface IClienteQuery
    {
        List<ResponseGetCliente> GetAllClientes(string nombre, string apellido, string dni);

        bool ExisteDNI(string dni);
    }
}