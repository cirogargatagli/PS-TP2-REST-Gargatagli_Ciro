using System.Collections.Generic;
using TP2.REST.Domain.Commands;
using TP2.REST.Domain.DTO;
using TP2.REST.Domain.Entities;
using TP2.REST.Domain.Queries;


namespace TP2.REST.Application.Services
{
    public interface IClienteService
    {
        GenericCreatedResponseDTO CreateCliente(ClienteDTO clienteDto);

        List<ResponseGetCliente> GetClientes(string nombre, string apellido, string dni);

        ResponseGetCliente GetByID(int clienteid);
        bool ExisteDNI(string dni);
    }
    public class ClienteService : IClienteService
    {
        private readonly IGenericRepository _repository;
        private readonly IClienteQuery _query;

        public ClienteService(IGenericRepository repository, IClienteQuery query)
        {
            _repository = repository;
            _query = query;
        }

        public GenericCreatedResponseDTO CreateCliente(ClienteDTO clienteDto)
        {
            var entity = new Cliente
            {
                Nombre = clienteDto.Nombre,
                Apellido = clienteDto.Apellido,
                DNI = clienteDto.DNI,
                Email = clienteDto.Email
            };
            _repository.Add(entity);
            return new GenericCreatedResponseDTO { Entity = "Cliente", Id = entity.ClienteId.ToString() };
        }

        public bool ExisteDNI(string dni)
        {
            return _query.ExisteDNI(dni);
        }

        public ResponseGetCliente GetByID(int clienteid)
        {
            return _query.GetByID(clienteid);
        }

        public List<ResponseGetCliente> GetClientes(string nombre, string apellido, string dni)
        {
            return _query.GetAllClientes(nombre, apellido, dni);
        }
    }
}