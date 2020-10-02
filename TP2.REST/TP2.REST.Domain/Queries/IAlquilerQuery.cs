using System.Collections.Generic;
using TP2.REST.Domain.DTO;

namespace TP2.REST.Domain.Queries
{
    public interface IAlquilerQuery
    {
        List<ResponseGetAlquilerByEstadoId> GetByEstadoID(int estadoid);

        GenericModifyResponseDTO ModifyReserva(int clienteid, string isbn);

        void ModifyStock(string isbn);
        List<ResponseGetLibro> GetLibroByCliente(int idcliente);
    }
}
