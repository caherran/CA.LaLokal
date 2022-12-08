using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Maestras.CaracteristicasExternas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.CaracteristicasExternas
{
    public class CaracteristicaExternaMap : EntityTypeConfiguration<CaracteristicaExterna>
    {
        public override void Configure(EntityTypeBuilder<CaracteristicaExterna> builder)
        {
            builder.ToTable("mas_" + nameof(CaracteristicaExterna));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}