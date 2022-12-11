using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesDocumentaciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.InmueblesDocumentaciones
{
    public class InmuebleDocumentacionMap : EntityTypeConfiguration<InmuebleDocumentacion>
    {
        public override void Configure(EntityTypeBuilder<InmuebleDocumentacion> builder)
        {
            builder.ToTable(nameof(InmuebleDocumentacion));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.InmuebleId).IsRequired().HasMaxLength(36);
            builder.Property(p => p.CopiaCedula).IsRequired().HasMaxLength(200);
            builder.Property(p => p.CertificadoCamaraComercio).IsRequired().HasMaxLength(200);
            builder.Property(p => p.CopiaEscrituraCompraventa).IsRequired().HasMaxLength(200);
            builder.Property(p => p.CopiaPromesaCompraventa).IsRequired().HasMaxLength(200);
            builder.Property(p => p.RUT).IsRequired().HasMaxLength(200);
            builder.Property(p => p.CertificadoLibertad).IsRequired().HasMaxLength(200);
            builder.Property(p => p.UltimoPagoImpuestoPredial).IsRequired().HasMaxLength(200);
            builder.Property(p => p.CopiaRecibosServiciosPublicosPagos).IsRequired().HasMaxLength(200);
            builder.Property(p => p.PazSalvoAdministración).IsRequired().HasMaxLength(200);
            builder.Property(p => p.FirmaContratoAdministración).IsRequired().HasMaxLength(200);
            builder.Property(p => p.EntregaCartaInstrucciones).IsRequired().HasMaxLength(200);
            builder.Property(p => p.ContratoCompraAlquiler).IsRequired().HasMaxLength(200);
            base.Configure(builder);
        }
    }
}