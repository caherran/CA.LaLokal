using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Maestras.EstadosUsuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.EstadosUsuario
{
    public class EstadoUsuarioMap : EntityTypeConfiguration<EstadoUsuario>
    {
        public override void Configure(EntityTypeBuilder<EstadoUsuario> builder)
        {
            builder.ToTable("mas_" + nameof(EstadoUsuario));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}