using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.LaLokal.Back.Domain.Maestras.TiposMoneda;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.TiposMoneda
{
    public class TipoMonedaMap : EntityTypeConfiguration<TipoMoneda>
    {
        public override void Configure(EntityTypeBuilder<TipoMoneda> builder)
        {
            builder.ToTable(nameof(TipoMoneda));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}