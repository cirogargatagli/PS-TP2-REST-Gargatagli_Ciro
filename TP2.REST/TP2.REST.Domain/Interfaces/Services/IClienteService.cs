using System.Collections.Generic;
using TP2.REST.Domain.DTO;

namespace TP2.REST.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        GenericCreatedResponseDTO CreateCliente(ClienteDTO clienteDto);

        List<ResponseGetCliente> GetClientes(string nombre, string apellido, string dni);

        string ValidarCliente(ClienteDTO cliente);
    }
}
