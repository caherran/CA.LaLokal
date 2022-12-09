using CA.LaLokal.Back.Application.Transacciones.Usuarios.UsuarioCQRS.Queries;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosRedesSociales;
using CA.Utils.AutoMapperUtils;
using System;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosRedesSociales.UsuarioRedSocialCQRS.Queries
{
    public class UsuarioRedSocialDto : IMapFrom<UsuarioRedSocial>
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public UsuarioDto Usuario { get; set; }
        public string URLFacebook { get; set; }
        public string URLTwitter { get; set; }
        public string URLLinkedIn { get; set; }
        public string URLInstagram { get; set; }

    }
}