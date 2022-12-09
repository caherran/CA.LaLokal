using CA.Domain.Auditable;
using CA.LaLokal.Back.Domain.Transacciones.Inmuebles;
using System;

namespace CA.LaLokal.Back.Domain.Transacciones.InmueblesMultimediaImagenes
{
    public class InmuebleMultimediaImagen : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid InmuebleId { get; set; }
        public virtual Inmueble Inmueble { get; set; }
        public string URLImagen { get; set; }

    }
}