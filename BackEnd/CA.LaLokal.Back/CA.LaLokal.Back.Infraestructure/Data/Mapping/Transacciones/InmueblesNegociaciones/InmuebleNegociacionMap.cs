using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesNegociaciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.InmueblesNegociaciones
{
    public class InmuebleNegociacionMap : EntityTypeConfiguration<InmuebleNegociacion>
    {
        public override void Configure(EntityTypeBuilder<InmuebleNegociacion> builder)
        {
            builder.ToTable(nameof(InmuebleNegociacion));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.InmuebleId).IsRequired().HasMaxLength(36);
            builder.Property(p => p.PrecioVenta).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.PrecioAlquiler).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.ValorAdministracion).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.TienePorcentajePrecio).IsRequired();
            builder.Property(p => p.ValorPorcentajePrecio).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.TieneCantIdadFija).IsRequired();
            builder.Property(p => p.ValorCantIdadFija).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.TieneContratoExclusivIdad).IsRequired();
            builder.Property(p => p.FechaExpiracionContrato).IsRequired();
            base.Configure(builder);
        }
    }
}