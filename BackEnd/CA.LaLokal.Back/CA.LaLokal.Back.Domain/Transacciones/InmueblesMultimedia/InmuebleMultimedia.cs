using CA.Domain.Auditable;
using CA.LaLokal.Back.Domain.Transacciones.Inmuebles;
using System;

namespace CA.LaLokal.Back.Domain.Transacciones.InmueblesMultimedia
{
    public class InmuebleMultimedia : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid InmuebleId { get; set; }
        public virtual Inmueble Inmueble { get; set; }
        public string URLVideo { get; set; }
        public string URLTour360 { get; set; }

    }
}