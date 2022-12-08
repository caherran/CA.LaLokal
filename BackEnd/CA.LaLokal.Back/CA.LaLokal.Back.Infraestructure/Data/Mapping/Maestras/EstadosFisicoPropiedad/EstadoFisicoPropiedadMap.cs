using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.LaLokal.Back.Domain.Maestras.EstadosFisicoPropiedad;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.EstadosFisicoPropiedad
{
    public class EstadoFisicoPropiedadMap : EntityTypeConfiguration<EstadoFisicoPropiedad>
    {
        public override void Configure(EntityTypeBuilder<EstadoFisicoPropiedad> builder)
        {
            builder.ToTable(nameof(EstadoFisicoPropiedad));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}