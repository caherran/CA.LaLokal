using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesUsuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.InmueblesUsuarios
{
    public class InmuebleUsuarioMap : EntityTypeConfiguration<InmuebleUsuario>
    {
        public override void Configure(EntityTypeBuilder<InmuebleUsuario> builder)
        {
            builder.ToTable(nameof(InmuebleUsuario));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.InmuebleId).IsRequired().HasMaxLength(36);
            builder.Property(p => p.UsuarioId).IsRequired().HasMaxLength(36);

            base.Configure(builder);
        }
    }
}