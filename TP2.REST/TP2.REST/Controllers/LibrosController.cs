using System;
using Microsoft.AspNetCore.Mvc;
using TP2.REST.Application.Services;
using TP2.REST.Domain.DTO;
using TP2.REST.Domain.Entities;

namespace TP2.REST.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService libroService;
        public LibroController(ILibroService service)
        {
            libroService = service;
        }

        [HttpPost]
        public Libro Post(LibroDTO libro)
        {
            return libroService.CreateLibro(libro);
        }

        [HttpGet]
        public IActionResult GetLibros([FromQuery] bool stock, [FromQuery] string autor, [FromQuery] string titulo)
        {
            try
            {
                return new JsonResult(libroService.GetLibros(stock, autor, titulo)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}