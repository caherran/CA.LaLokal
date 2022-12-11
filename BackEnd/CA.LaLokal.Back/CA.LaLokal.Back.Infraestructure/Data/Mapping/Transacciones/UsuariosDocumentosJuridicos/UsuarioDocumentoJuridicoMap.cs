using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosJuridicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.UsuariosDocumentosJuridicos
{
    public class UsuarioDocumentoJuridicoMap : EntityTypeConfiguration<UsuarioDocumentoJuridico>
    {
        public override void Configure(EntityTypeBuilder<UsuarioDocumentoJuridico> builder)
        {
            builder.ToTable(nameof(UsuarioDocumentoJuridico));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.UsuarioId).IsRequired().HasMaxLength(36);
            builder.Property(p => p.ExtractoBancario).IsRequired().HasMaxLength(200);
            builder.Property(p => p.DeclaracionRenta).IsRequired().HasMaxLength(200);
            builder.Property(p => p.CertificadoCamaraComercio).IsRequired().HasMaxLength(200);
            builder.Property(p => p.EstadosFinancieros).IsRequired().HasMaxLength(200);
            builder.Property(p => p.CopiaCedulaRepresentanteLegal).IsRequired().HasMaxLength(200);
            base.Configure(builder);
        }
    }
}