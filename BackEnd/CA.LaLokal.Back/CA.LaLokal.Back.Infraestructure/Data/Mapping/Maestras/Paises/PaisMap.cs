using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.LaLokal.Back.Domain.Maestras.Paises;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.Paises
{
    public class PaisMap : EntityTypeConfiguration<Pais>
    {
        public override void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable(nameof(Pais));
            builder.Property(p => p.Codigo).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}