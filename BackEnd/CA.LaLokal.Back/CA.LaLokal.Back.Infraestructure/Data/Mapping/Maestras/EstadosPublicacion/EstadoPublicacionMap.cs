using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Maestras.EstadosPublicacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.EstadosPublicacion
{
    public class EstadoPublicacionMap : EntityTypeConfiguration<EstadoPublicacion>
    {
        public override void Configure(EntityTypeBuilder<EstadoPublicacion> builder)
        {
            builder.ToTable("mas_" + nameof(EstadoPublicacion));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}