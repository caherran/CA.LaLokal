using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Maestras.EstadosCartera;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.EstadosCartera
{
    public class EstadoCarteraMap : EntityTypeConfiguration<EstadoCartera>
    {
        public override void Configure(EntityTypeBuilder<EstadoCartera> builder)
        {
            builder.ToTable("mas_" + nameof(EstadoCartera));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}