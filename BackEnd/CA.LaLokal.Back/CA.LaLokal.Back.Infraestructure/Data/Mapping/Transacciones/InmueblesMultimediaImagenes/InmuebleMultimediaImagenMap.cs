using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesMultimediaImagenes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.InmueblesMultimediaImagenes
{
    public class InmuebleMultimediaImagenMap : EntityTypeConfiguration<InmuebleMultimediaImagen>
    {
        public override void Configure(EntityTypeBuilder<InmuebleMultimediaImagen> builder)
        {
            builder.ToTable(nameof(InmuebleMultimediaImagen));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.InmuebleId).IsRequired().HasMaxLength(36);
            builder.Property(p => p.URLImagen).IsRequired().HasMaxLength(200);
            base.Configure(builder);
        }
    }
}