using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Maestras.Banos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.Banos
{
    public class BanoMap : EntityTypeConfiguration<Bano>
    {
        public override void Configure(EntityTypeBuilder<Bano> builder)
        {
            builder.ToTable("mas_" + nameof(Bano));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}