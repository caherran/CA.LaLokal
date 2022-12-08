using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Maestras.TiposUsuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.TiposUsuario
{
    public class TipoUsuarioMap : EntityTypeConfiguration<TipoUsuario>
    {
        public override void Configure(EntityTypeBuilder<TipoUsuario> builder)
        {
            builder.ToTable("mas_" + nameof(TipoUsuario));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}