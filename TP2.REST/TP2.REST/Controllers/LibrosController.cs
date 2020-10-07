using Microsoft.AspNetCore.Mvc;
using System;
using TP2.REST.Application.Services;

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

        [HttpGet]
        public IActionResult GetLibros([FromQuery] bool? stock, [FromQuery] string autor, [FromQuery] string titulo)
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