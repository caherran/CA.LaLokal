using CA.LaLokal.Back.Domain.Maestras.Departamentos;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.Ciudades
{
    public class Ciudad : BaseEntity
    {
        public int Id { get; set; }
        public int DepartamentoId { get; set; }
        public virtual Departamento Departamento { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

    }
}