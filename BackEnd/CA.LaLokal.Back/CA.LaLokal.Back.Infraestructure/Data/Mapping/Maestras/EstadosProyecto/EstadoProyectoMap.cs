using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.LaLokal.Back.Domain.Maestras.EstadosProyecto;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.EstadosProyecto
{
    public class EstadoProyectoMap : EntityTypeConfiguration<EstadoProyecto>
    {
        public override void Configure(EntityTypeBuilder<EstadoProyecto> builder)
        {
            builder.ToTable(nameof(EstadoProyecto));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}