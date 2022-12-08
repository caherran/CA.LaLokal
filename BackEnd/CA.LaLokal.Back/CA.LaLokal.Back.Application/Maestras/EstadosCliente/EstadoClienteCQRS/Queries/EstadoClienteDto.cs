using System;
using CA.LaLokal.Back.Domain.Maestras.EstadosCliente;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosCliente.EstadoClienteCQRS.Queries
{
    public class EstadoClienteDto : IMapFrom<EstadoCliente>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}