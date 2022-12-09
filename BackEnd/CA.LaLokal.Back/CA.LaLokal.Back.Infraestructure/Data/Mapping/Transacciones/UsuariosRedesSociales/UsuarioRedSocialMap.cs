using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosRedesSociales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.UsuariosRedesSociales
{
    public class UsuarioRedSocialMap : EntityTypeConfiguration<UsuarioRedSocial>
    {
        public override void Configure(EntityTypeBuilder<UsuarioRedSocial> builder)
        {
            builder.ToTable(nameof(UsuarioRedSocial));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.UsuarioId).IsRequired().HasMaxLength(36);
            builder.Property(p => p.URLFacebook).IsRequired().HasMaxLength(80);
            builder.Property(p => p.URLTwitter).IsRequired().HasMaxLength(80);
            builder.Property(p => p.URLLinkedIn).IsRequired().HasMaxLength(80);
            builder.Property(p => p.URLInstagram).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}