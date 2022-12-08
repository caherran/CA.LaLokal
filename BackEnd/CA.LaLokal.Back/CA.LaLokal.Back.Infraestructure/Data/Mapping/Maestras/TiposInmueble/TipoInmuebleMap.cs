using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.LaLokal.Back.Domain.Maestras.TiposInmueble;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.TiposInmueble
{
    public class TipoInmuebleMap : EntityTypeConfiguration<TipoInmueble>
    {
        public override void Configure(EntityTypeBuilder<TipoInmueble> builder)
        {
            builder.ToTable(nameof(TipoInmueble));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}