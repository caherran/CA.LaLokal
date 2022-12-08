using System;
using CA.LaLokal.Back.Domain.Maestras.TiposCliente;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposCliente.TipoClienteCQRS.Queries
{
    public class TipoClienteDto : IMapFrom<TipoCliente>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}