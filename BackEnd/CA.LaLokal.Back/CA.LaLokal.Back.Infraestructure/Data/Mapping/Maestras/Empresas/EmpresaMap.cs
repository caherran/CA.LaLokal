using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.LaLokal.Back.Domain.Maestras.Empresas;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.Empresas
{
    public class EmpresaMap : EntityTypeConfiguration<Empresa>
    {
        public override void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable(nameof(Empresa));
            builder.Property(p => p.Nombre).IsRequired().HasMaxLength(80);
            builder.Property(p => p.NIT).IsRequired().HasMaxLength(80);
            builder.Property(p => p.Direccion).IsRequired().HasMaxLength(80);
            builder.Property(p => p.NombreContacto).IsRequired().HasMaxLength(80);
            builder.Property(p => p.CelularContacto).IsRequired().HasMaxLength(80); builder.Property(p => p.CorreoElectronico).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}