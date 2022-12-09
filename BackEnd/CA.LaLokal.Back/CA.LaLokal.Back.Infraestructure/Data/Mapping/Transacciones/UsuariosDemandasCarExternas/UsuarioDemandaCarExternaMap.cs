using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDemandasCarExternas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.UsuariosDemandasCarExternas
{
    public class UsuarioDemandaCarExternaMap : EntityTypeConfiguration<UsuarioDemandaCarExterna>
    {
        public override void Configure(EntityTypeBuilder<UsuarioDemandaCarExterna> builder)
        {
            builder.ToTable(nameof(UsuarioDemandaCarExterna));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.UsuarioDemandaId).IsRequired().HasMaxLength(36);

            base.Configure(builder);
        }
    }
}