using CA.Domain.Auditable;
using CA.LaLokal.Back.Domain.Maestras.Ciudades;
using CA.LaLokal.Back.Domain.Maestras.ZonasBarrios;

namespace CA.LaLokal.Back.Domain.Maestras.Empresas
{
    public class Empresa : BaseEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NIT { get; set; }
        public int CiudadId { get; set; }
        public virtual Ciudad Ciudad { get; set; }
        public int ZonaBarrioId { get; set; }
        public virtual ZonaBarrio ZonaBarrio { get; set; }
        public string Direccion { get; set; }
        public string NombreContacto { get; set; }
        public string CelularContacto { get; set; }
        public string CorreoElectronico { get; set; }

    }
}