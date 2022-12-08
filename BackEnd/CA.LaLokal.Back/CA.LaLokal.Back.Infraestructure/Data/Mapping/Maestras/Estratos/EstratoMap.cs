using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Maestras.Estratos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.Estratos
{
    public class EstratoMap : EntityTypeConfiguration<Estrato>
    {
        public override void Configure(EntityTypeBuilder<Estrato> builder)
        {
            builder.ToTable("mas_" + nameof(Estrato));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}