using CA.Domain.Auditable;
using CA.LaLokal.Back.Domain.Transacciones.Usuarios;
using System;

namespace CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosJuridicos
{
    public class UsuarioDocumentoJuridico : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public string ExtractoBancario { get; set; }
        public string DeclaracionRenta { get; set; }
        public string CertificadoCamaraComercio { get; set; }
        public string EstadosFinancieros { get; set; }
        public string CopiaCedulaRepresentanteLegal { get; set; }
    }
}