using Castle.Core.Internal;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using System;
using TP2.REST.Domain.DTO;
using TP2.REST.Domain.Interfaces.Services;

namespace TP2.REST.Presentation.Controllers
{
    [Route("api/alquiler")]
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
                ResponseBadRequest validar = alquilerService.ValidarAlquiler(alquilerDTO);
                return (validar==null ? new JsonResult(alquilerService.CreateAlquiler(alquilerDTO)) { StatusCode = 201 } : new JsonResult(validar) { StatusCode = 400 });
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

        [HttpGet("cliente/{id}")]
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

        [HttpPatch]
        public IActionResult Patch(int clienteid, string isbn)
        {
            try
            {
                ResponseBadRequest validar = alquilerService.ValidarModifyReserva(clienteid,isbn);
                if (validar != null)
                {
                    return new JsonResult(validar) { StatusCode = 400 };                    
                }
                alquilerService.ModifyReserva(clienteid, isbn);
                return new StatusCodeResult(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}