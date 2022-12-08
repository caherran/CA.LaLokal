using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.LaLokal.Back.Domain.Maestras.TiposPersona;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.TiposPersona
{
    public class TipoPersonaMap : EntityTypeConfiguration<TipoPersona>
    {
        public override void Configure(EntityTypeBuilder<TipoPersona> builder)
        {
            builder.ToTable(nameof(TipoPersona));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}