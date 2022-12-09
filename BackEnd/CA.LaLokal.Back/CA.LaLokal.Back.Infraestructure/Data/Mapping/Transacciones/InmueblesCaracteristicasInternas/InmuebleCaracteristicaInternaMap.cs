using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesCaracteristicasInternas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.InmueblesCaracteristicasInternas
{
    public class InmuebleCaracteristicaInternaMap : EntityTypeConfiguration<InmuebleCaracteristicaInterna>
    {
        public override void Configure(EntityTypeBuilder<InmuebleCaracteristicaInterna> builder)
        {
            builder.ToTable(nameof(InmuebleCaracteristicaInterna));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.InmuebleId).IsRequired().HasMaxLength(36);

            base.Configure(builder);
        }
    }
}