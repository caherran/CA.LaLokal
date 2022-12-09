using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDemandasCarInternas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.UsuariosDemandasCarInternas
{
    public class UsuarioDemandaCarInternaMap : EntityTypeConfiguration<UsuarioDemandaCarInterna>
    {
        public override void Configure(EntityTypeBuilder<UsuarioDemandaCarInterna> builder)
        {
            builder.ToTable(nameof(UsuarioDemandaCarInterna));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.UsuarioDemandaId).IsRequired().HasMaxLength(36);

            base.Configure(builder);
        }
    }
}