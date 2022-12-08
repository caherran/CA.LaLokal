using CA.LaLokal.Back.Domain.Maestras.Paises;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.Departamentos
{
    public class Departamento : BaseEntity
    {
        public int Id { get; set; }
        public int PaisId { get; set; }
        public virtual Pais Pais { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

    }
}