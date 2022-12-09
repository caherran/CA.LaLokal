using CA.Domain.Auditable;
using CA.LaLokal.Back.Domain.Transacciones.Inmuebles;
using CA.LaLokal.Back.Domain.Transacciones.Usuarios;
using System;

namespace CA.LaLokal.Back.Domain.Transacciones.InmueblesCompartir
{
    public class InmuebleCompartir : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid InmuebleId { get; set; }
        public virtual Inmueble Inmueble { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public string Asunto { get; set; }

    }
}