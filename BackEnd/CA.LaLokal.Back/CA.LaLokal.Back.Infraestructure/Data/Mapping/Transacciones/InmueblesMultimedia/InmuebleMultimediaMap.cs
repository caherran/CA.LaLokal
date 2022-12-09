using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesMultimedia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.InmueblesMultimedia
{
    public class InmuebleMultimediaMap : EntityTypeConfiguration<InmuebleMultimedia>
    {
        public override void Configure(EntityTypeBuilder<InmuebleMultimedia> builder)
        {
            builder.ToTable(nameof(InmuebleMultimedia));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.InmuebleId).IsRequired().HasMaxLength(36);
            builder.Property(p => p.URLVideo).IsRequired().HasMaxLength(80);
            builder.Property(p => p.URLTour360).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}