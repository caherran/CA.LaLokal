using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.Proyectos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.Proyectos
{
    public class ProyectoMap : EntityTypeConfiguration<Proyecto>
    {
        public override void Configure(EntityTypeBuilder<Proyecto> builder)
        {
            builder.ToTable(nameof(Proyecto));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.UsuarioEncargadoId).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Codigo).IsRequired().HasMaxLength(80);
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            builder.Property(p => p.MontoTotal).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.MontoMinimoInversion).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.MontoMaximoInversion).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.RentabilIdadTotal).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.RentabilIdadAnalizada).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.PlazoRetornoEsperado).IsRequired().HasMaxLength(80);
            builder.Property(p => p.TotalAFinanciar).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.CostoProyecto).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.IngresoEstimadoVenta).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.RentabilIdad).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.CreacionSpA).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.InscripciónSpA).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.EstudioTítulos).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.PromesaEscrituraCompra).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.InscripciónPropiedadCBR).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.ContabilIdadRentaAnual).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.ContabilIdadMensual).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.Contribuciones).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.PatenteComercialSpA).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.CompraTerreno).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.ComisiónCorretajeCompra).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.ProyectoParcelación).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.MarketingVenta).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.FondoReservaProyecto).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.PromesaEscrituraVenta).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.CierreSpA).IsRequired().HasColumnType("decimal(18,2)");
            base.Configure(builder);
        }
    }
}