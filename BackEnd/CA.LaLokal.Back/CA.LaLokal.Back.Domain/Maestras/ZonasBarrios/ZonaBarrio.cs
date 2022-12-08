using CA.LaLokal.Back.Domain.Maestras.Ciudades;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.ZonasBarrios
{
    public class ZonaBarrio : BaseEntity
    {
        public int Id { get; set; }
        public int CiudadId { get; set; }
        public virtual Ciudad Ciudad { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

    }
}