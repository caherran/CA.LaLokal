using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Maestras.TiposPersona;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.TiposPersona
{
    public class TipoPersonaMap : EntityTypeConfiguration<TipoPersona>
    {
        public override void Configure(EntityTypeBuilder<TipoPersona> builder)
        {
            builder.ToTable("mas_" + nameof(TipoPersona));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}