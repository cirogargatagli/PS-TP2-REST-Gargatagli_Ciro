using TP2.REST.Domain.Commands;
using TP2.REST.Domain.DTO;
using TP2.REST.Domain.Entities;

namespace TP2.REST.Application.Services
{
    public interface IEstadoAlquilerService
    {
        EstadoAlquiler CreateEstadoAlquiler(EstadoAlquilerDTO alquiler);
    }
    public class EstadoAlquilerService : IEstadoAlquilerService
    {
        private readonly IGenericRepository estadoalquilerRepository;
        public EstadoAlquilerService(IGenericRepository repository)
        {
            estadoalquilerRepository = repository;
        }

        public EstadoAlquiler CreateEstadoAlquiler(EstadoAlquilerDTO estadoAlquiler)
        {
            var entity = new EstadoAlquiler
            {
                Descripcion = estadoAlquiler.Descripcion
            };
            estadoalquilerRepository.Add<EstadoAlquiler>(entity);
            return entity;
        }
    }
}
