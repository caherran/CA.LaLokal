using CA.LaLokal.Back.Application.Maestras.ZonasBarrios.ZonaBarrioCQRS.Queries;
using CA.LaLokal.Back.Domain.Maestras.ZonasGeografias;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.ZonasGeografias.ZonaGeograficaCQRS.Queries
{
    public class ZonaGeograficaDto : IMapFrom<ZonaGeografica>
    {
        public int Id { get; set; }
        public int ZonaBarrioId { get; set; }
        public ZonaBarrioDto ZonaBarrio { get; set; }

    }
}