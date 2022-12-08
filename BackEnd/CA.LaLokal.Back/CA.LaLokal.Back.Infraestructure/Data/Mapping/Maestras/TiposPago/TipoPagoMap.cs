using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Maestras.TiposPago;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.TiposPago
{
    public class TipoPagoMap : EntityTypeConfiguration<TipoPago>
    {
        public override void Configure(EntityTypeBuilder<TipoPago> builder)
        {
            builder.ToTable("mas_" + nameof(TipoPago));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}