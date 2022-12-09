using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.Usuarios
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public override void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(nameof(Usuario));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.UsuarioEncargadoId).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Nombres).IsRequired().HasMaxLength(80);
            builder.Property(p => p.ApellIdos).IsRequired().HasMaxLength(80);
            builder.Property(p => p.CorreoElectronico).IsRequired().HasMaxLength(80);
            builder.Property(p => p.TelefonoFijo).IsRequired().HasMaxLength(80);
            builder.Property(p => p.TelefonoMovil).IsRequired().HasMaxLength(80);
            builder.Property(p => p.FechaNacimiento).IsRequired();
            builder.Property(p => p.NumeroIdentificacion).IsRequired().HasMaxLength(80);
            builder.Property(p => p.ReferidoPor).IsRequired().HasMaxLength(80);
            builder.Property(p => p.DatosAdicionales).IsRequired().HasMaxLength(80);
            builder.Property(p => p.Direccion).IsRequired().HasMaxLength(80);
            builder.Property(p => p.Observaciones).IsRequired().HasMaxLength(80);
            builder.Property(p => p.CopiaCedula).IsRequired().HasMaxLength(80);
            builder.Property(p => p.ContratoPrestacion).IsRequired().HasMaxLength(80);
            builder.Property(p => p.RUT).IsRequired().HasMaxLength(80);
            builder.Property(p => p.URLFoto).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}