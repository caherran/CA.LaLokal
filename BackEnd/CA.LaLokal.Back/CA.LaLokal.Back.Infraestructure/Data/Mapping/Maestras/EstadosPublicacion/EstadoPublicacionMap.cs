using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.LaLokal.Back.Domain.Maestras.EstadosPublicacion;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.EstadosPublicacion
{
    public class EstadoPublicacionMap : EntityTypeConfiguration<EstadoPublicacion>
    {
        public override void Configure(EntityTypeBuilder<EstadoPublicacion> builder)
        {
            builder.ToTable(nameof(EstadoPublicacion));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}