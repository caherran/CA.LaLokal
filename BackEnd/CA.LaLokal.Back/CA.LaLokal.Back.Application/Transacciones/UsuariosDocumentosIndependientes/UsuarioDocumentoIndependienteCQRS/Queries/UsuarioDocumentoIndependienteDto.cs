using CA.LaLokal.Back.Application.Transacciones.Usuarios.UsuarioCQRS.Queries;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosIndependientes;
using CA.Utils.AutoMapperUtils;
using System;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosIndependientes.UsuarioDocumentoIndependienteCQRS.Queries
{
    public class UsuarioDocumentoIndependienteDto : IMapFrom<UsuarioDocumentoIndependiente>
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public UsuarioDto Usuario { get; set; }
        public string ExtractoBancario3meses { get; set; }
        public string DeclaracionRenta2UltimosAnos { get; set; }
        public string CertificadoCamaraComercio { get; set; }
        public string CopiaDocumentoIdentidad { get; set; }

    }
}