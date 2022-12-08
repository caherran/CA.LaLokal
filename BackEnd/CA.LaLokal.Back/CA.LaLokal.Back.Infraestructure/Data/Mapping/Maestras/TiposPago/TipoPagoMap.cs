using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.LaLokal.Back.Domain.Maestras.TiposPago;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.TiposPago
{
    public class TipoPagoMap : EntityTypeConfiguration<TipoPago>
    {
        public override void Configure(EntityTypeBuilder<TipoPago> builder)
        {
            builder.ToTable(nameof(TipoPago));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}