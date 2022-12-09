using CA.LaLokal.Back.Application.Transacciones.Usuarios.UsuarioCQRS.Queries;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosJuridicos;
using CA.Utils.AutoMapperUtils;
using System;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosJuridicos.UsuarioDocumentoJuridicoCQRS.Queries
{
    public class UsuarioDocumentoJuridicoDto : IMapFrom<UsuarioDocumentoJuridico>
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public UsuarioDto Usuario { get; set; }
        public string ExtractoBancario { get; set; }
        public string DeclaracionRenta { get; set; }
        public string CertificadoCamaraComercio { get; set; }
        public string EstadosFinancieros { get; set; }
        public string CopiaCedulaRepresentanteLegal { get; set; }

    }
}