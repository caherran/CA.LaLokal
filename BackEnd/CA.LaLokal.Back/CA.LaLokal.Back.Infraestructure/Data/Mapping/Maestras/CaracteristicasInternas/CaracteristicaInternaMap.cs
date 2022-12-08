using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.LaLokal.Back.Domain.Maestras.CaracteristicasInternas;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.CaracteristicasInternas
{
    public class CaracteristicaInternaMap : EntityTypeConfiguration<CaracteristicaInterna>
    {
        public override void Configure(EntityTypeBuilder<CaracteristicaInterna> builder)
        {
            builder.ToTable(nameof(CaracteristicaInterna));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}