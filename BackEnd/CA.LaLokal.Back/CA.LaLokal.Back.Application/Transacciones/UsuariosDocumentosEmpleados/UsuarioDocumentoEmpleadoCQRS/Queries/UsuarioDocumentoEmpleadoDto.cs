using CA.LaLokal.Back.Application.Transacciones.Usuarios.UsuarioCQRS.Queries;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosEmpleados;
using CA.Utils.AutoMapperUtils;
using System;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosEmpleados.UsuarioDocumentoEmpleadoCQRS.Queries
{
    public class UsuarioDocumentoEmpleadoDto : IMapFrom<UsuarioDocumentoEmpleado>
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public UsuarioDto Usuario { get; set; }
        public string ExtractoBancario3meses { get; set; }
        public string CertificadoLaboral { get; set; }
        public string DeclaracionRenta2UltimosAnos { get; set; }
        public string CopiaDocumentoIdentidad { get; set; }

    }
}