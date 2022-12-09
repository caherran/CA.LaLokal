using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.Inmuebles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.Inmuebles
{
    public class InmuebleMap : EntityTypeConfiguration<Inmueble>
    {
        public override void Configure(EntityTypeBuilder<Inmueble> builder)
        {
            builder.ToTable(nameof(Inmueble));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Nombre).IsRequired().HasMaxLength(80);
            builder.Property(p => p.Codigo).IsRequired().HasMaxLength(80);
            builder.Property(p => p.GestorInmuebleId).IsRequired().HasMaxLength(36);
            builder.Property(p => p.MatriculaInmobiliaria).IsRequired().HasMaxLength(80);
            builder.Property(p => p.Ano).IsRequired().HasMaxLength(80);
            builder.Property(p => p.AreaPrivada).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.AreaConstruIda).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.AreaTotal).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.ValorGasNatural).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.ValorTelefoniaInternet).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.ValorEnergia).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.ValorAgua).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.CodigoPostal).IsRequired().HasMaxLength(80);
            builder.Property(p => p.Direccion).IsRequired().HasMaxLength(80);
            builder.Property(p => p.NoPublicar).IsRequired();
            builder.Property(p => p.SoloZona).IsRequired();
            builder.Property(p => p.PuntoExacto).IsRequired();
            builder.Property(p => p.DireccionMapa).IsRequired().HasMaxLength(80);
            builder.Property(p => p.Observaciones).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}