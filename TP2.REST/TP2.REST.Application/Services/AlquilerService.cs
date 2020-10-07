using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using TP2.REST.Domain.DTO;
using TP2.REST.Domain.Entities;
using TP2.REST.Domain.Interfaces.Commands;
using TP2.REST.Domain.Interfaces.Queries;
using TP2.REST.Domain.Interfaces.Services;

namespace TP2.REST.Application.Services
{
    public class AlquilerService : IAlquilerService
    {
        private readonly IGenericRepository _repository;
        private readonly IAlquilerQuery _query;

        public AlquilerService(IGenericRepository repository, IAlquilerQuery query)
        {
            _repository = repository;
            _query = query;
        }

        public ResponseBadRequest ValidarAlquiler(AlquilerDTO alquiler)
        {
            if (!_query.ExisteCliente(alquiler.ClienteID))
                return new ResponseBadRequest { CódigoError = 400, Error = "No existe un cliente registrado con el ID ingresado." };

            if (!_query.ExisteLibro(alquiler.ISBN))
                return new ResponseBadRequest { CódigoError = 400, Error = "No existe un libro registrado con el Isbn ingresado" };            

            if (!_query.ExisteStock(alquiler.ISBN))
                return new ResponseBadRequest { CódigoError = 400, Error = "No existe stock del libro que desea alquilar o reservar" };
            
            if (alquiler.FechaAlquiler.IsNullOrEmpty() && alquiler.FechaReserva.IsNullOrEmpty())
                return new ResponseBadRequest { CódigoError = 400, Error = "No ingresó ninguna fecha. Recuerde ingresar la fecha correspondiente al tipo de registro que desea realizar: alquiler o reserva." };
            
            if (!alquiler.FechaAlquiler.IsNullOrEmpty() && !alquiler.FechaReserva.IsNullOrEmpty())
                return new ResponseBadRequest { CódigoError = 400, Error = "Solo se puede ingresar una fecha. Recuerde ingresar la fecha correspondiente al tipo de registro que desea realizar: alquiler o reserva." };
            
            if (alquiler.FechaAlquiler.IsNullOrEmpty())
                if (!Validacion.ValidarFecha(alquiler.FechaReserva))
                    return new ResponseBadRequest { CódigoError = 400, Error = "La fecha ingresada no se expresó en un formato válido. Recuerde utilizar el formato DD/MM/AAAA" };
            
            if (alquiler.FechaReserva.IsNullOrEmpty())
                if (!Validacion.ValidarFecha(alquiler.FechaAlquiler))
                    new ResponseBadRequest { CódigoError = 400, Error = "La fecha ingresada no se expresó en un formato válido. Recuerde utilizar el formato DD/MM/AAAA" };

            return null;
        }

        public ResponseBadRequest ValidarModifyReserva(int clienteid, string isbn)
        {
            if (_query.ExisteReservaDelCliente(clienteid))
                return new ResponseBadRequest { CódigoError = 400, Error = "No existe una reserva del cliente ingresado" };
            if (_query.ExisteReservaDelLibro(isbn))
                return new ResponseBadRequest { CódigoError = 400, Error = "No existe una reserva del libro ingresado" };            
            return null;
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
                _repository.Add<Alquiler>(entity);
                Libro libro = _query.GetLibro(alquiler.ISBN);
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

        public List<ResponseGetLibrosByCliente> GetLibroByCliente(int idcliente)
        {
            return _query.GetLibroByCliente(idcliente);
        }

        public List<ResponseGetAlquilerByEstadoId> GetByEstadoID(int estadoid)
        {
            return _query.GetByEstadoID(estadoid);
        }

        public void ModifyReserva(int clienteid, string isbn)
        {
            List<Alquiler> reservas = _query.GetReserva(clienteid, isbn);
            foreach (Alquiler reserva in reservas)
            {
                reserva.EstadoID = 2;
                reserva.FechaAlquiler = DateTime.Now;
                reserva.FechaDevolucion = DateTime.Now.AddDays(7);
            }
            _repository.UpdateRange(reservas);
            _repository.SaveChanges();
        }
    }
}