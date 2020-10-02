using Microsoft.AspNetCore.Mvc;
using TP2.REST.Application.Services;
using TP2.REST.Domain.DTO;
using TP2.REST.Domain.Entities;

namespace TP2.REST.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoAlquilerController : ControllerBase
    {
        private readonly IEstadoAlquilerService estadoalquilerService;
        public EstadoAlquilerController(IEstadoAlquilerService service)
        {
            estadoalquilerService = service;            
        }

        [HttpPost]
        public EstadoAlquiler Post(EstadoAlquilerDTO cliente)
        {
            return estadoalquilerService.CreateEstadoAlquiler(cliente);
        }
    }
}
