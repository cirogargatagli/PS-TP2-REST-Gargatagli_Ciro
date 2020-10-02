﻿using System.Collections.Generic;
using TP2.REST.Domain.DTO;

namespace TP2.REST.Domain.Queries
{
    public interface IClienteQuery
    {
        List<ResponseGetCliente> GetAllClientes(string nombre, string apellido, string dni);

        ResponseGetCliente GetByID(int clienteid);
        bool ExisteDNI(string dni);
    }
}