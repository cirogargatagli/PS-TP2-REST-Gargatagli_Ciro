using System;
using System.Collections.Generic;
using System.Text;

namespace TP2.REST.Domain.DTO
{
    public class ResponseGetLibrosByCliente
    {
        public string ISBN { get; set; }

        public string Titulo { get; set; }

        public string Autor { get; set; }

        public string Editorial { get; set; }

        public string Edicion { get; set; }
    }
}
