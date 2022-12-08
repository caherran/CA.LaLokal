using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Maestras.EstadosFisicoPropiedad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.EstadosFisicoPropiedad
{
    public class EstadoFisicoPropiedadMap : EntityTypeConfiguration<EstadoFisicoPropiedad>
    {
        public override void Configure(EntityTypeBuilder<EstadoFisicoPropiedad> builder)
        {
            builder.ToTable("mas_" + nameof(EstadoFisicoPropiedad));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}