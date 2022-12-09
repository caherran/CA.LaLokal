using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.ProyectosDocumentos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.ProyectosDocumentos
{
    public class ProyectoDocumentoMap : EntityTypeConfiguration<ProyectoDocumento>
    {
        public override void Configure(EntityTypeBuilder<ProyectoDocumento> builder)
        {
            builder.ToTable(nameof(ProyectoDocumento));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.InmuebleId).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            builder.Property(p => p.URLDocumento).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}