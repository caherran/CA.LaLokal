using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosInmuebles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.UsuariosInmuebles
{
    public class UsuarioInmuebleMap : EntityTypeConfiguration<UsuarioInmueble>
    {
        public override void Configure(EntityTypeBuilder<UsuarioInmueble> builder)
        {
            builder.ToTable(nameof(UsuarioInmueble));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.UsuarioId).IsRequired().HasMaxLength(36);
            builder.Property(p => p.InmuebleId).IsRequired().HasMaxLength(36);
            base.Configure(builder);
        }
    }
}