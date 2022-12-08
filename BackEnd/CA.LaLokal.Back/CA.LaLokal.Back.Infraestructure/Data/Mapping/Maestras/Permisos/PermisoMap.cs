using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Maestras.Permisos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.Permisos
{
    public class PermisoMap : EntityTypeConfiguration<Permiso>
    {
        public override void Configure(EntityTypeBuilder<Permiso> builder)
        {
            builder.ToTable("mas_" + nameof(Permiso));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}