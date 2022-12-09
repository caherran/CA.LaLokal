using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.LaLokal.Back.Domain.Maestras.TiposIdentificacion;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.TiposIdentificacion
{
    public class TipoIdentificacionMap : EntityTypeConfiguration<TipoIdentificacion>
    {
        public override void Configure(EntityTypeBuilder<TipoIdentificacion> builder)
        {
            builder.ToTable(nameof(TipoIdentificacion));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}