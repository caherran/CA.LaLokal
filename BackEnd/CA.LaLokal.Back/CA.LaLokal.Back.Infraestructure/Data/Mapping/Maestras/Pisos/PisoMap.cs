using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.LaLokal.Back.Domain.Maestras.Pisos;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.Pisos
{
    public class PisoMap : EntityTypeConfiguration<Piso>
    {
        public override void Configure(EntityTypeBuilder<Piso> builder)
        {
            builder.ToTable(nameof(Piso));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}