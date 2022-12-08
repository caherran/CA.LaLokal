using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Maestras.ZonasBarrios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.ZonasBarrios
{
    public class ZonaBarrioMap : EntityTypeConfiguration<ZonaBarrio>
    {
        public override void Configure(EntityTypeBuilder<ZonaBarrio> builder)
        {
            builder.ToTable("mas_" + nameof(ZonaBarrio));
            builder.Property(p => p.Codigo).IsRequired().HasMaxLength(80); builder.Property(p => p.Nombre).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}