using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosEmpleados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.UsuariosDocumentosEmpleados
{
    public class UsuarioDocumentoEmpleadoMap : EntityTypeConfiguration<UsuarioDocumentoEmpleado>
    {
        public override void Configure(EntityTypeBuilder<UsuarioDocumentoEmpleado> builder)
        {
            builder.ToTable(nameof(UsuarioDocumentoEmpleado));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.UsuarioId).IsRequired().HasMaxLength(36);
            builder.Property(p => p.ExtractoBancario3meses).IsRequired().HasMaxLength(80);
            builder.Property(p => p.CertificadoLaboral).IsRequired().HasMaxLength(80);
            builder.Property(p => p.DeclaracionRenta2UltimosAnos).IsRequired().HasMaxLength(80);
            builder.Property(p => p.CopiaDocumentoIdentidad).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}