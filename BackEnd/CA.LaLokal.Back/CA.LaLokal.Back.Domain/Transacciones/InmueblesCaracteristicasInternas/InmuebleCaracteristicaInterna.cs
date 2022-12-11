using CA.Domain.Auditable;
using CA.LaLokal.Back.Domain.Maestras.CaracteristicasInternas;
using CA.LaLokal.Back.Domain.Transacciones.Inmuebles;
using System;

namespace CA.LaLokal.Back.Domain.Transacciones.InmueblesCaracteristicasInternas
{
    public class InmuebleCaracteristicaInterna : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid InmuebleId { get; set; }
        public virtual Inmueble Inmueble { get; set; }
        public int CaracteristicaInternaId { get; set; }
        public virtual CaracteristicaInterna CaracteristicaInterna { get; set; }
    }
}