using CA.LaLokal.Back.Application.Maestras.Permisos.PermisoCQRS.Queries;
using CA.LaLokal.Back.Application.Maestras.Roles.RolCQRS.Queries;
using CA.LaLokal.Back.Domain.Maestras.PermisosRol;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.PermisosRol.PermisoRolCQRS.Queries
{
    public class PermisoRolDto : IMapFrom<PermisoRol>
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public RolDto Rol { get; set; }
        public int PermisoId { get; set; }
        public PermisoDto Permiso { get; set; }
        public string Estatus { get; set; }

    }
}