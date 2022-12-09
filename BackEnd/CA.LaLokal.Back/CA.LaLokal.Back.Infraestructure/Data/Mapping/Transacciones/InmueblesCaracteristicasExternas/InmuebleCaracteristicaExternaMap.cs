using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesCaracteristicasExternas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.InmueblesCaracteristicasExternas
{
    public class InmuebleCaracteristicaExternaMap : EntityTypeConfiguration<InmuebleCaracteristicaExterna>
    {
        public override void Configure(EntityTypeBuilder<InmuebleCaracteristicaExterna> builder)
        {
            builder.ToTable(nameof(InmuebleCaracteristicaExterna));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.InmuebleId).IsRequired().HasMaxLength(36);

            base.Configure(builder);
        }
    }
}