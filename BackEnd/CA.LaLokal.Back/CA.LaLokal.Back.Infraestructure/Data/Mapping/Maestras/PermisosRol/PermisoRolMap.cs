using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.LaLokal.Back.Domain.Maestras.PermisosRol;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.PermisosRol
{
    public class PermisoRolMap : EntityTypeConfiguration<PermisoRol>
    {
        public override void Configure(EntityTypeBuilder<PermisoRol> builder)
        {
            builder.ToTable(nameof(PermisoRol));
            builder.Property(p => p.Estatus).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}