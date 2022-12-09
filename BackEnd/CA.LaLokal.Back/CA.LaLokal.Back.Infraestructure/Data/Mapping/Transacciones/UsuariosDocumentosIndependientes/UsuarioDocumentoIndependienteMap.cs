using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosIndependientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.UsuariosDocumentosIndependientes
{
    public class UsuarioDocumentoIndependienteMap : EntityTypeConfiguration<UsuarioDocumentoIndependiente>
    {
        public override void Configure(EntityTypeBuilder<UsuarioDocumentoIndependiente> builder)
        {
            builder.ToTable(nameof(UsuarioDocumentoIndependiente));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.UsuarioId).IsRequired().HasMaxLength(36);
            builder.Property(p => p.ExtractoBancario3meses).IsRequired().HasMaxLength(80);
            builder.Property(p => p.DeclaracionRenta2UltimosAnos).IsRequired().HasMaxLength(80);
            builder.Property(p => p.CertificadoCamaraComercio).IsRequired().HasMaxLength(80);
            builder.Property(p => p.CopiaDocumentoIdentidad).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}