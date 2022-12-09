using CA.Domain.Auditable;
using CA.LaLokal.Back.Domain.Transacciones.Inmuebles;
using System;

namespace CA.LaLokal.Back.Domain.Transacciones.ProyectosDocumentos
{
    public class ProyectoDocumento : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid InmuebleId { get; set; }
        public virtual Inmueble Inmueble { get; set; }
        public string Descripcion { get; set; }
        public string URLDocumento { get; set; }

    }
}