using CA.LaLokal.Back.Application.Transacciones.Usuarios.UsuarioCQRS.Queries;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosPensionados;
using CA.Utils.AutoMapperUtils;
using System;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosPensionados.UsuarioDocumentoPensionadoCQRS.Queries
{
    public class UsuarioDocumentoPensionadoDto : IMapFrom<UsuarioDocumentoPensionado>
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public UsuarioDto Usuario { get; set; }
        public string ExtractoBancario3meses { get; set; }
        public string CertificadoPagoPension { get; set; }
        public string CopiaDocumentoIdentidad { get; set; }

    }
}