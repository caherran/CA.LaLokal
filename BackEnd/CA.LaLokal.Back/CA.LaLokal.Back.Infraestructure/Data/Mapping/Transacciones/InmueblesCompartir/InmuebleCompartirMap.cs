using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesCompartir;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.InmueblesCompartir
{
    public class InmuebleCompartirMap : EntityTypeConfiguration<InmuebleCompartir>
    {
        public override void Configure(EntityTypeBuilder<InmuebleCompartir> builder)
        {
            builder.ToTable(nameof(InmuebleCompartir));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.InmuebleId).IsRequired().HasMaxLength(36);
            builder.Property(p => p.UsuarioId).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Asunto).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}