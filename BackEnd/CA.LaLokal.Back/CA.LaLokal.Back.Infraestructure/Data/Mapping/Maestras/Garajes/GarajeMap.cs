using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Maestras.Garajes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.Garajes
{
    public class GarajeMap : EntityTypeConfiguration<Garaje>
    {
        public override void Configure(EntityTypeBuilder<Garaje> builder)
        {
            builder.ToTable("mas_" + nameof(Garaje));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}