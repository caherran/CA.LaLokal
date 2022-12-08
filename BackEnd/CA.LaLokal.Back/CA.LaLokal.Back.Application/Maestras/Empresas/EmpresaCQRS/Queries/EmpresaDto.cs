using CA.LaLokal.Back.Application.Maestras.Ciudades.CiudadCQRS.Queries;
using CA.LaLokal.Back.Application.Maestras.ZonasBarrios.ZonaBarrioCQRS.Queries;
using CA.LaLokal.Back.Domain.Maestras.Empresas;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Empresas.EmpresaCQRS.Queries
{
    public class EmpresaDto : IMapFrom<Empresa>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NIT { get; set; }
        public int CiudadId { get; set; }
        public CiudadDto Ciudad { get; set; }
        public int ZonaBarrioId { get; set; }
        public ZonaBarrioDto ZonaBarrio { get; set; }
        public string Direccion { get; set; }
        public string NombreContacto { get; set; }
        public string CelularContacto { get; set; }
        public string CorreoElectronico { get; set; }

    }
}