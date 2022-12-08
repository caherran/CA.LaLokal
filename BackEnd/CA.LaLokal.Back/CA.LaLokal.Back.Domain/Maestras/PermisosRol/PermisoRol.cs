using CA.LaLokal.Back.Domain.Maestras.Permisos;
using CA.LaLokal.Back.Domain.Maestras.Roles;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.PermisosRol
{
    public class PermisoRol : BaseEntity
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public virtual Rol Rol { get; set; }
        public int PermisoId { get; set; }
        public virtual Permiso Permiso { get; set; }
        public string Estatus { get; set; }

    }
}