using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.LaLokal.Back.Domain.Maestras.TiposUsuario;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.TiposUsuario
{
    public class TipoUsuarioMap : EntityTypeConfiguration<TipoUsuario>
    {
        public override void Configure(EntityTypeBuilder<TipoUsuario> builder)
        {
            builder.ToTable(nameof(TipoUsuario));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}