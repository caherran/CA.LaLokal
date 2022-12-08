using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.LaLokal.Back.Domain.Maestras.TiposCliente;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.TiposCliente
{
    public class TipoClienteMap : EntityTypeConfiguration<TipoCliente>
    {
        public override void Configure(EntityTypeBuilder<TipoCliente> builder)
        {
            builder.ToTable(nameof(TipoCliente));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}