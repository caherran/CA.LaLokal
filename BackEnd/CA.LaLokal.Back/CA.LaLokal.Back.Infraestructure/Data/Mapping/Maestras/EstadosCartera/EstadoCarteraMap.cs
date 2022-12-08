using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.LaLokal.Back.Domain.Maestras.EstadosCartera;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.EstadosCartera
{
    public class EstadoCarteraMap : EntityTypeConfiguration<EstadoCartera>
    {
        public override void Configure(EntityTypeBuilder<EstadoCartera> builder)
        {
            builder.ToTable(nameof(EstadoCartera));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}