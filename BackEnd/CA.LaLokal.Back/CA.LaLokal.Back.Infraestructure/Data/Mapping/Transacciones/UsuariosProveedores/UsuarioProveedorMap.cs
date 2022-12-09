using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosProveedores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.UsuariosProveedores
{
    public class UsuarioProveedorMap : EntityTypeConfiguration<UsuarioProveedor>
    {
        public override void Configure(EntityTypeBuilder<UsuarioProveedor> builder)
        {
            builder.ToTable(nameof(UsuarioProveedor));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.UsuarioId).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Foto).IsRequired().HasMaxLength(80);
            builder.Property(p => p.Nombre).IsRequired().HasMaxLength(80);
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            builder.Property(p => p.PaginaWeb).IsRequired().HasMaxLength(80);
            builder.Property(p => p.URLFacebook).IsRequired().HasMaxLength(80);
            builder.Property(p => p.URLInstagram).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}