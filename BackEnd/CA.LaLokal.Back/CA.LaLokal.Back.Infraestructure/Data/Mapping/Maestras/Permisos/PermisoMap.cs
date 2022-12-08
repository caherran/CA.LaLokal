using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.LaLokal.Back.Domain.Maestras.Permisos;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.Permisos
{
    public class PermisoMap : EntityTypeConfiguration<Permiso>
    {
        public override void Configure(EntityTypeBuilder<Permiso> builder)
        {
            builder.ToTable(nameof(Permiso));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);

            base.Configure(builder);
        }
    }
}