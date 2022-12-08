using CA.LaLokal.Back.Domain.Maestras.Funcionalidades;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.Permisos
{
    public class Permiso : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int FuncionalIdadId { get; set; }
        public virtual Funcionalidad Funcionalidad { get; set; }

    }
}