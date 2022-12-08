using System;
using CA.LaLokal.Back.Domain.Maestras.TiposMoneda;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposMoneda.TipoMonedaCQRS.Queries
{
    public class TipoMonedaDto : IMapFrom<TipoMoneda>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}