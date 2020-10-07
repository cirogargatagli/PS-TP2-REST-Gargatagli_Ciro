using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        List<GenericModifyResponseDTO> ModifyReserva(int clienteid, string isbn);
        List<ResponseGetLibro> GetLibroByCliente(int idcliente);
        string ValidarAlquiler(AlquilerDTO alquilerDTO);
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
        
        public string ValidarAlquiler(AlquilerDTO alquiler)
        {
            if (!_query.ExisteCliente(alquiler.ClienteID))
                return "No existe un cliente registrado con el ID ingresado.";

            if (!_query.ExisteLibro(alquiler.ISBN))
                return "No existe un libro registrado con el Isbn ingresado";

            if (!_query.ExisteStock(alquiler.ISBN))
                return "No existe stock del libro que desea alquilar o reservar";

            if (alquiler.FechaAlquiler.IsNullOrEmpty() && alquiler.FechaReserva.IsNullOrEmpty())
                return "No ingresó ninguna fecha. Recuerde ingresar la fecha correspondiente al tipo de registro que desea realizar: alquiler o reserva.";

            if (!alquiler.FechaAlquiler.IsNullOrEmpty() && !alquiler.FechaReserva.IsNullOrEmpty())
                return "Solo se puede ingresar una fecha. Recuerde ingresar la fecha correspondiente al tipo de registro que desea realizar: alquiler o reserva.";

            if (alquiler.FechaAlquiler.IsNullOrEmpty())
                if (!Validacion.ValidarFecha(alquiler.FechaReserva))
                    return "La fecha ingresada no se expresó en un formato válido. Recuerde utilizar el formato DD/MM/AAAA";

            if (alquiler.FechaReserva.IsNullOrEmpty())
                if (!Validacion.ValidarFecha(alquiler.FechaAlquiler))
                    return "La fecha ingresada no se expresó en un formato válido. Recuerde utilizar el formato DD/MM/AAAA";
            return "";
        }

        public GenericCreatedResponseDTO CreateAlquiler(AlquilerDTO alquiler)
        {
            if (alquiler.FechaAlquiler.IsNullOrEmpty())
            {
                DateTime.TryParse(alquiler.FechaReserva, out DateTime fechaValidada);
                var entity = new Alquiler
                {
                    ClienteID = alquiler.ClienteID,
                    ISBN = alquiler.ISBN,
                    EstadoID = 1,
                    FechaReserva = fechaValidada
                };
                Libro libro = _query.GetLibro(alquiler.ISBN);
                _repository.Add<Alquiler>(entity);

                libro.Stock -= 1;
                _repository.Update<Libro>(libro);
                _repository.SaveChanges();
                return new GenericCreatedResponseDTO { Entity = "Alquiler", Id = entity.AlquilerId.ToString() };
            }
            else
            {
                DateTime.TryParse(alquiler.FechaAlquiler, out DateTime fechaValidada);
                var entity = new Alquiler
                {
                    ClienteID = alquiler.ClienteID,
                    ISBN = alquiler.ISBN,
                    EstadoID = 2,
                    FechaAlquiler = fechaValidada,
                    FechaDevolucion = fechaValidada.AddDays(7)
                };
                Libro libro = _query.GetLibro(alquiler.ISBN);
                _repository.Add<Alquiler>(entity);
                libro.Stock -= 1;
                _repository.Update<Libro>(libro);
                _repository.SaveChanges();
                return new GenericCreatedResponseDTO { Entity = "Alquiler", Id = entity.AlquilerId.ToString() };
            }
        }

        public List<ResponseGetLibro> GetLibroByCliente(int idcliente)
        {
            return _query.GetLibroByCliente(idcliente);
        }

        public List<ResponseGetAlquilerByEstadoId> GetByEstadoID(int estadoid)
        {
            return _query.GetByEstadoID(estadoid);
        }

        public List<GenericModifyResponseDTO> ModifyReserva(int clienteid, string isbn)
        {
            List<Alquiler> reservas = _query.GetReserva(clienteid, isbn);
            List<GenericModifyResponseDTO> reservasModificadas = new List<GenericModifyResponseDTO>();
            foreach (Alquiler reserva in reservas)
            {
                reserva.EstadoID = 2;
                reserva.FechaAlquiler = DateTime.Now;
                reserva.FechaDevolucion = DateTime.Now.AddDays(7);
                reservasModificadas.Add(new GenericModifyResponseDTO { Entity = "Alquiler", Id = reserva.AlquilerId, Estado = "Modificado" });
            }
            _repository.UpdateRange(reservas);
            _repository.SaveChanges();

            return reservasModificadas;
        }
    }
}