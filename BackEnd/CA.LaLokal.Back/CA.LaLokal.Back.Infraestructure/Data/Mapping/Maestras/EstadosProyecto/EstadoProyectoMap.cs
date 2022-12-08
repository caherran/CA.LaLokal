using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Maestras.EstadosProyecto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.EstadosProyecto
{
    public class EstadoProyectoMap : EntityTypeConfiguration<EstadoProyecto>
    {
        public override void Configure(EntityTypeBuilder<EstadoProyecto> builder)
        {
            builder.ToTable("mas_" + nameof(EstadoProyecto));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}