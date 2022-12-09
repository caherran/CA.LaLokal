using CA.LaLokal.Back.Application.Maestras.CaracteristicasExternas.CaracteristicaExternaCQRS.Queries;
using CA.LaLokal.Back.Application.Transacciones.Inmuebles.InmuebleCQRS.Queries;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesCaracteristicasExternas;
using CA.Utils.AutoMapperUtils;
using System;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesCaracteristicasExternas.InmuebleCaracteristicaExternaCQRS.Queries
{
    public class InmuebleCaracteristicaExternaDto : IMapFrom<InmuebleCaracteristicaExterna>
    {
        public Guid Id { get; set; }
        public Guid InmuebleId { get; set; }
        public InmuebleDto Inmueble { get; set; }
        public int CaracteristicaExternaId { get; set; }
        public CaracteristicaExternaDto CaracteristicaExterna { get; set; }

    }
}