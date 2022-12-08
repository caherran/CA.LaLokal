using System;
using CA.LaLokal.Back.Domain.Maestras.TiposPersona;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposPersona.TipoPersonaCQRS.Queries
{
    public class TipoPersonaDto : IMapFrom<TipoPersona>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}