using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Transacciones.ProyectosInmuebles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Transacciones.ProyectosInmuebles
{
    public class ProyectoInmuebleMap : EntityTypeConfiguration<ProyectoInmueble>
    {
        public override void Configure(EntityTypeBuilder<ProyectoInmueble> builder)
        {
            builder.ToTable(nameof(ProyectoInmueble));
            builder.Property(p => p.Id).IsRequired().HasMaxLength(36);
            builder.Property(p => p.InmuebleId).IsRequired().HasMaxLength(36);
            base.Configure(builder);
        }
    }
}