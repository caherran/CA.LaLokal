using CA.LaLokal.Back.Domain.Maestras.ZonasBarrios;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.ZonasGeografias
{
    public class ZonaGeografica : BaseEntity
    {
        public int Id { get; set; }
        public int ZonaBarrioId { get; set; }
        public virtual ZonaBarrio ZonaBarrio { get; set; }

    }
}