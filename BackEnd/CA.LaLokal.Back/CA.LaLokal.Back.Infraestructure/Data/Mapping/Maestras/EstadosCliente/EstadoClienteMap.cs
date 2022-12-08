using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Maestras.EstadosCliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.EstadosCliente
{
    public class EstadoClienteMap : EntityTypeConfiguration<EstadoCliente>
    {
        public override void Configure(EntityTypeBuilder<EstadoCliente> builder)
        {
            builder.ToTable("mas_" + nameof(EstadoCliente));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}