using CA.LaLokal.Back.Domain.Maestras.Alcobas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Alcobas
{
    public class AlcobaMap : EntityTypeConfiguration<Alcoba>
    {
        public override void Configure(EntityTypeBuilder<Alcoba> builder)
        {
            builder.ToTable(nameof(Alcoba));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}