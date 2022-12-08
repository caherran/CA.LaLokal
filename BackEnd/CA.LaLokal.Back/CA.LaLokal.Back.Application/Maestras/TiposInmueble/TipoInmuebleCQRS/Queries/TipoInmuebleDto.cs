using System;
using CA.LaLokal.Back.Domain.Maestras.TiposInmueble;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposInmueble.TipoInmuebleCQRS.Queries
{
    public class TipoInmuebleDto : IMapFrom<TipoInmueble>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}