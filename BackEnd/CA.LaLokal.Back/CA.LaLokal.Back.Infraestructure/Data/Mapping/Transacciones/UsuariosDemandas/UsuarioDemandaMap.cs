using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDemandas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.UsuariosDemandas
{
    public class UsuarioDemandaMap : EntityTypeConfiguration<UsuarioDemanda>
    {
        public override void Configure(EntityTypeBuilder<UsuarioDemanda> builder)
        {
            builder.ToTable(nameof(UsuarioDemanda));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.UsuarioId).IsRequired().HasMaxLength(36);
            builder.Property(p => p.PresupuestoMinimo).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.PresupuestoMaximo).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.AreaMinima).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.AreaMaxima).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.DetallePropiedad).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}