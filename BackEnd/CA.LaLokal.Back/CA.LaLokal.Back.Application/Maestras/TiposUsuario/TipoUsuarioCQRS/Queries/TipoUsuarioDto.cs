using System;
using CA.LaLokal.Back.Domain.Maestras.TiposUsuario;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposUsuario.TipoUsuarioCQRS.Queries
{
    public class TipoUsuarioDto : IMapFrom<TipoUsuario>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}