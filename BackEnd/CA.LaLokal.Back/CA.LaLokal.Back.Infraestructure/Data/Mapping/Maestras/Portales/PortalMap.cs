using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.LaLokal.Back.Domain.Maestras.Portales;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.Portales
{
    public class PortalMap : EntityTypeConfiguration<Portal>
    {
        public override void Configure(EntityTypeBuilder<Portal> builder)
        {
            builder.ToTable(nameof(Portal));
            builder.Property(p => p.Nombre).IsRequired().HasMaxLength(80);
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            builder.Property(p => p.URLPortal).IsRequired().HasMaxLength(80); builder.Property(p => p.Estatus).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}