using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Maestras.TiposCliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.TiposCliente
{
    public class TipoClienteMap : EntityTypeConfiguration<TipoCliente>
    {
        public override void Configure(EntityTypeBuilder<TipoCliente> builder)
        {
            builder.ToTable("mas_" + nameof(TipoCliente));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}