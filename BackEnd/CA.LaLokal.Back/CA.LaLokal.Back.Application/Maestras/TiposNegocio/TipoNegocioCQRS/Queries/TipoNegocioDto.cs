using System;
using CA.LaLokal.Back.Domain.Maestras.TiposNegocio;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposNegocio.TipoNegocioCQRS.Queries
{
    public class TipoNegocioDto : IMapFrom<TipoNegocio>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}