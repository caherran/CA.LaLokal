using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Maestras.Ciudades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.Ciudades
{
    public class CiudadMap : EntityTypeConfiguration<Ciudad>
    {
        public override void Configure(EntityTypeBuilder<Ciudad> builder)
        {
            builder.ToTable("mas_" + nameof(Ciudad));
            builder.Property(p => p.Codigo).IsRequired().HasMaxLength(80); builder.Property(p => p.Nombre).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}