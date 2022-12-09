using CA.Domain.Auditable;
using CA.LaLokal.Back.Domain.Maestras.CaracteristicasExternas;
using CA.LaLokal.Back.Domain.Transacciones.Inmuebles;
using System;

namespace CA.LaLokal.Back.Domain.Transacciones.InmueblesCaracteristicasExternas
{
    public class InmuebleCaracteristicaExterna : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid InmuebleId { get; set; }
        public virtual Inmueble Inmueble { get; set; }
        public int CaracteristicaExternaId { get; set; }
        public virtual CaracteristicaExterna CaracteristicaExterna { get; set; }

    }
}