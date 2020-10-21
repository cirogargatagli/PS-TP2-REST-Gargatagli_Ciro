using Castle.Core.Internal;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using TP2.REST.Domain.DTO;
using TP2.REST.Domain.Interfaces.Services;

namespace TP2.REST.Presentation.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService clienteService;
        public ClienteController(IClienteService service)
        {
            clienteService = service;
        }

        [HttpPost]
        public IActionResult Post(ClienteDTO cliente)
        {
            try
            {
                string validar = clienteService.ValidarCliente(cliente);
                return (validar.IsNullOrEmpty() ? new JsonResult(clienteService.CreateCliente(cliente)) { StatusCode = 201 } : new JsonResult(validar) { StatusCode = 400 });
            }
            catch (Exception e)
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}