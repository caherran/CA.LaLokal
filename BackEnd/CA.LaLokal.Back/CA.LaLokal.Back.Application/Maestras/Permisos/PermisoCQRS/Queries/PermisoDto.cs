using CA.LaLokal.Back.Application.Maestras.Funcionalidades.FuncionalidadCQRS.Queries;
using CA.LaLokal.Back.Domain.Maestras.Permisos;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Permisos.PermisoCQRS.Queries
{
    public class PermisoDto : IMapFrom<Permiso>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int FuncionalIdadId { get; set; }
        public FuncionalidadDto Funcionalidad { get; set; }

    }
}