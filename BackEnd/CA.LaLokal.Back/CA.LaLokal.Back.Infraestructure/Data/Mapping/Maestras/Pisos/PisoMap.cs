using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Maestras.Pisos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.Pisos
{
    public class PisoMap : EntityTypeConfiguration<Piso>
    {
        public override void Configure(EntityTypeBuilder<Piso> builder)
        {
            builder.ToTable("mas_" + nameof(Piso));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}