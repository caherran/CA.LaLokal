using CA.LaLokal.Back.Application.Maestras.Ciudades.CiudadCQRS.Queries;
using CA.LaLokal.Back.Domain.Maestras.ZonasBarrios;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.ZonasBarrios.ZonaBarrioCQRS.Queries
{
    public class ZonaBarrioDto : IMapFrom<ZonaBarrio>
    {
        public int Id { get; set; }
        public int CiudadId { get; set; }
        public CiudadDto Ciudad { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

    }
}