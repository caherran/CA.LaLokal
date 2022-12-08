using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.LaLokal.Back.Domain.Maestras.Tiempos;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.Tiempos
{
    public class TiempoMap : EntityTypeConfiguration<Tiempo>
    {
        public override void Configure(EntityTypeBuilder<Tiempo> builder)
        {
            builder.ToTable(nameof(Tiempo));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}