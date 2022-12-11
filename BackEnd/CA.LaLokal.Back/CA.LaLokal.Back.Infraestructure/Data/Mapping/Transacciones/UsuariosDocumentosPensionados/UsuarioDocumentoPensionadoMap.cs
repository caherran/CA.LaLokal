using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosPensionados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.UsuariosDocumentosPensionados
{
    public class UsuarioDocumentoPensionadoMap : EntityTypeConfiguration<UsuarioDocumentoPensionado>
    {
        public override void Configure(EntityTypeBuilder<UsuarioDocumentoPensionado> builder)
        {
            builder.ToTable(nameof(UsuarioDocumentoPensionado));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.UsuarioId).IsRequired().HasMaxLength(36);
            builder.Property(p => p.ExtractoBancario3meses).IsRequired().HasMaxLength(200);
            builder.Property(p => p.CertificadoPagoPension).IsRequired().HasMaxLength(200);
            builder.Property(p => p.CopiaDocumentoIdentidad).IsRequired().HasMaxLength(200);
            base.Configure(builder);
        }
    }
}