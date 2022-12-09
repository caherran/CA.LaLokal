using CA.LaLokal.Back.Domain.Maestras.EstadosUsuario;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosUsuario.EstadoUsuarioCQRS.Queries
{
    public class EstadoUsuarioDto : IMapFrom<EstadoUsuario>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}