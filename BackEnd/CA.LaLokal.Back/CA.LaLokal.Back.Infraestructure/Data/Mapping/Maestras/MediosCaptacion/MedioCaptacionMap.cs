using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.LaLokal.Back.Domain.Maestras.MediosCaptacion;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.MediosCaptacion
{
    public class MedioCaptacionMap : EntityTypeConfiguration<MedioCaptacion>
    {
        public override void Configure(EntityTypeBuilder<MedioCaptacion> builder)
        {
            builder.ToTable(nameof(MedioCaptacion));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}