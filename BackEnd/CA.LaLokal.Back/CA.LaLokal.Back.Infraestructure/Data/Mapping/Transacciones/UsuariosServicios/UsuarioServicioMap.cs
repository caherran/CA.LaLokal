using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosServicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.UsuariosServicios
{
    public class UsuarioServicioMap : EntityTypeConfiguration<UsuarioServicio>
    {
        public override void Configure(EntityTypeBuilder<UsuarioServicio> builder)
        {
            builder.ToTable(nameof(UsuarioServicio));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.UsuarioId).IsRequired().HasMaxLength(36);

            base.Configure(builder);
        }
    }
}