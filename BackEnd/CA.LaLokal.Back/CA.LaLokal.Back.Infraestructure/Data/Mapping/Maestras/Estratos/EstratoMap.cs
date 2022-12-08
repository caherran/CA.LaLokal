using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.LaLokal.Back.Domain.Maestras.Estratos;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.Estratos
{
    public class EstratoMap : EntityTypeConfiguration<Estrato>
    {
        public override void Configure(EntityTypeBuilder<Estrato> builder)
        {
            builder.ToTable(nameof(Estrato));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}