using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using System;
using TP2.REST.Application.Services;
using TP2.REST.Domain.DTO;

namespace TP2.REST.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlquilerController : ControllerBase
    {
        private readonly IAlquilerService alquilerService;
        public AlquilerController(IAlquilerService service)
        {
            alquilerService = service;
        }

        [HttpPost]
        public IActionResult Post(AlquilerDTO alquilerDTO)
        {
            try
            {
                string validar = alquilerService.ValidarAlquiler(alquilerDTO);
                return (validar.IsNullOrEmpty() ? new JsonResult(alquilerService.CreateAlquiler(alquilerDTO)) { StatusCode = 201 } : new JsonResult(validar) { StatusCode = 400 });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetByEstado([FromQuery] int estadoid)
        {
            try
            {
                return new JsonResult(alquilerService.GetByEstadoID(estadoid)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Cliente/{id}")]
        public IActionResult GetByCliente(int id)
        {
            try
            {
                return new JsonResult(alquilerService.GetLibroByCliente(id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(int clienteid, string isbn)
        {
            try
            {
                return new JsonResult(alquilerService.ModifyReserva(clienteid, isbn)) { StatusCode = 204 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}