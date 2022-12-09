using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosEducacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.UsuariosEducacion
{
    public class UsuarioEducacionMap : EntityTypeConfiguration<UsuarioEducacion>
    {
        public override void Configure(EntityTypeBuilder<UsuarioEducacion> builder)
        {
            builder.ToTable(nameof(UsuarioEducacion));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.UsuarioId).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Titulo).IsRequired().HasMaxLength(80);
            builder.Property(p => p.InstitucionUniversidad).IsRequired().HasMaxLength(80);
            builder.Property(p => p.Direccion).IsRequired().HasMaxLength(80);
            builder.Property(p => p.EstudiaActualmente).IsRequired();
            builder.Property(p => p.FechaInicio).IsRequired();
            builder.Property(p => p.FechaFinalizacion).IsRequired();
            base.Configure(builder);
        }
    }
}