using System;
using Microsoft.AspNetCore.Mvc;
using TP2.REST.Application.Services;
using TP2.REST.Domain.DTO;

namespace TP2.REST.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService clienteService;
        public ClientesController(IClienteService service)
        {
            clienteService = service;            
        }

        [HttpPost]
        public IActionResult Post(ClienteDTO cliente)
        {            
            try
            {
                if (clienteService.ExisteDNI(cliente.DNI))
                    return new JsonResult("Ya existe") { StatusCode = 400 };
                return new JsonResult(clienteService.CreateCliente(cliente)) { StatusCode = 201 };
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetClientes([FromQuery] string nombre, [FromQuery] string apellido, [FromQuery] string dni)
        {
            try
            {
                return new JsonResult(clienteService.GetClientes(nombre, apellido, dni)) { StatusCode = 200 };
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetClienteByID(int id)
        {
            try
            {
                return new JsonResult(clienteService.GetByID(id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}