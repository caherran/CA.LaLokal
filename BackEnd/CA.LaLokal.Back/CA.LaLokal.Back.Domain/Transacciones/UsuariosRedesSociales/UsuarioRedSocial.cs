using CA.Domain.Auditable;
using CA.LaLokal.Back.Domain.Transacciones.Usuarios;
using System;

namespace CA.LaLokal.Back.Domain.Transacciones.UsuariosRedesSociales
{
    public class UsuarioRedSocial : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public string URLFacebook { get; set; }
        public string URLTwitter { get; set; }
        public string URLLinkedIn { get; set; }
        public string URLInstagram { get; set; }
    }
}