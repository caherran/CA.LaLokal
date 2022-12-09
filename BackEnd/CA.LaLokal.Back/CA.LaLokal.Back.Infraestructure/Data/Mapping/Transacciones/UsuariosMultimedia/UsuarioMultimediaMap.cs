using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosMultimedia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.UsuariosMultimedia
{
    public class UsuarioMultimediaMap : EntityTypeConfiguration<UsuarioMultimedia>
    {
        public override void Configure(EntityTypeBuilder<UsuarioMultimedia> builder)
        {
            builder.ToTable(nameof(UsuarioMultimedia));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.UsuarioId).IsRequired().HasMaxLength(36);
            builder.Property(p => p.URLImagen).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}