using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.ProyectosInversionistas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.ProyectosInversionistas
{
    public class ProyectoInversionistaMap : EntityTypeConfiguration<ProyectoInversionista>
    {
        public override void Configure(EntityTypeBuilder<ProyectoInversionista> builder)
        {
            builder.ToTable(nameof(ProyectoInversionista));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.InmuebleId).IsRequired().HasMaxLength(36);
            builder.Property(p => p.UsuarioInversionistaId).IsRequired().HasMaxLength(36);
            base.Configure(builder);
        }
    }
}