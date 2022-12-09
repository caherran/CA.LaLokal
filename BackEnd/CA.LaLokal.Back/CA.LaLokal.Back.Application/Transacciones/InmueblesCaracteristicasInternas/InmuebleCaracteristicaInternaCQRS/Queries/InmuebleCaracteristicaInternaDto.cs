using CA.LaLokal.Back.Application.Maestras.CaracteristicasInternas.CaracteristicaInternaCQRS.Queries;
using CA.LaLokal.Back.Application.Transacciones.Inmuebles.InmuebleCQRS.Queries;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesCaracteristicasInternas;
using CA.Utils.AutoMapperUtils;
using System;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesCaracteristicasInternas.InmuebleCaracteristicaInternaCQRS.Queries
{
    public class InmuebleCaracteristicaInternaDto : IMapFrom<InmuebleCaracteristicaInterna>
    {
        public Guid Id { get; set; }
        public Guid InmuebleId { get; set; }
        public InmuebleDto Inmueble { get; set; }
        public int CaracteristicaInternaId { get; set; }
        public CaracteristicaInternaDto CaracteristicaInterna { get; set; }

    }
}