using CA.Domain.Auditable;
using CA.LaLokal.Back.Domain.Transacciones.Usuarios;
using System;

namespace CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosIndependientes
{
    public class UsuarioDocumentoIndependiente : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public string ExtractoBancario3meses { get; set; }
        public string DeclaracionRenta2UltimosAnos { get; set; }
        public string CertificadoCamaraComercio { get; set; }
        public string CopiaDocumentoIdentidad { get; set; }

    }
}