using CA.Domain.Auditable;
using CA.LaLokal.Back.Domain.Transacciones.Inmuebles;
using CA.LaLokal.Back.Domain.Transacciones.Usuarios;
using System;

namespace CA.LaLokal.Back.Domain.Transacciones.ProyectosInversionistas
{
    public class ProyectoInversionista : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid InmuebleId { get; set; }
        public virtual Inmueble Inmueble { get; set; }
        public Guid UsuarioInversionistaId { get; set; }
        public virtual Usuario UsuarioInversionista { get; set; }
    }
}