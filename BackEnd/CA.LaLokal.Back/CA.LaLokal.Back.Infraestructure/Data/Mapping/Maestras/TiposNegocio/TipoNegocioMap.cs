using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.LaLokal.Back.Domain.Maestras.TiposNegocio;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.TiposNegocio
{
    public class TipoNegocioMap : EntityTypeConfiguration<TipoNegocio>
    {
        public override void Configure(EntityTypeBuilder<TipoNegocio> builder)
        {
            builder.ToTable(nameof(TipoNegocio));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}