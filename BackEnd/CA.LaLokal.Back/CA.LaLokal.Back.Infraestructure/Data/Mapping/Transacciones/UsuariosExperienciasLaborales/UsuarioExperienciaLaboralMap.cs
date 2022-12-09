using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosExperienciasLaborales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.UsuariosExperienciasLaborales
{
    public class UsuarioExperienciaLaboralMap : EntityTypeConfiguration<UsuarioExperienciaLaboral>
    {
        public override void Configure(EntityTypeBuilder<UsuarioExperienciaLaboral> builder)
        {
            builder.ToTable(nameof(UsuarioExperienciaLaboral));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.UsuarioId).IsRequired().HasMaxLength(36);
            builder.Property(p => p.NombreEmpresa).IsRequired().HasMaxLength(80);
            builder.Property(p => p.Cargo).IsRequired().HasMaxLength(80);
            builder.Property(p => p.Direccion).IsRequired().HasMaxLength(80);
            builder.Property(p => p.TrabajaActualmente).IsRequired();
            builder.Property(p => p.FechaInicio).IsRequired();
            builder.Property(p => p.FechaFinalizacion).IsRequired();
            base.Configure(builder);
        }
    }
}