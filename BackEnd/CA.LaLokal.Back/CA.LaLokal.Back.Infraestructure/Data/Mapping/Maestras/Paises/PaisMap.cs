using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Maestras.Paises;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.Paises
{
    public class PaisMap : EntityTypeConfiguration<Pais>
    {
        public override void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("mas_" + nameof(Pais));
            builder.Property(p => p.Codigo).IsRequired().HasMaxLength(10);
            builder.Property(p => p.Nombre).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}