using System;
using System.Collections.Generic;
using TP2.REST.Domain.Commands;
using TP2.REST.Domain.DTO;
using TP2.REST.Domain.Entities;
using TP2.REST.Domain.Queries;

namespace TP2.REST.Application.Services
{
    public interface IAlquilerService
    {
        GenericCreatedResponseDTO CreateAlquiler(AlquilerDTO alquiler);
        List<ResponseGetAlquilerByEstadoId> GetByEstadoID(int estadoid);
        GenericModifyResponseDTO ModifyReserva(int clienteid, string isbn);
        List<ResponseGetLibro> GetLibroByCliente(int idcliente);
    }

    public class AlquilerService : IAlquilerService
    {
        private readonly IGenericRepository _repository;
        private readonly IAlquilerQuery _query;

        public AlquilerService(IGenericRepository repository, IAlquilerQuery query)
        {
            _repository = repository;
            _query = query;
        }

        public GenericCreatedResponseDTO CreateAlquiler(AlquilerDTO alquiler)
        {
            if(alquiler.FechaAlquiler == null && alquiler.FechaReserva == null)
            {
                throw new Exception();
            }
            var entity = new Alquiler
            {
                ClienteID = alquiler.ClienteID,
                ISBN = alquiler.ISBN,
                EstadoID = (alquiler.FechaAlquiler == null ? 1 : 2),
                FechaReserva = alquiler.FechaReserva,
                FechaAlquiler = alquiler.FechaAlquiler
            };
            _repository.Add<Alquiler>(entity);
            _query.ModifyStock(alquiler.ISBN);
            return new GenericCreatedResponseDTO { Entity = "Alquiler", Id = entity.AlquilerId.ToString() };
        }

        public List<ResponseGetLibro> GetLibroByCliente(int idcliente)
        {
            return _query.GetLibroByCliente(idcliente);
        }

        public List<ResponseGetAlquilerByEstadoId> GetByEstadoID(int estadoid)
        {
            return _query.GetByEstadoID(estadoid);
        }

        public GenericModifyResponseDTO ModifyReserva(int clienteid, string isbn)
        {
            return _query.ModifyReserva(clienteid, isbn);
        }
    }
}