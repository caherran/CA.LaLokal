using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.LaLokal.Back.Domain.Maestras.Roles;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.Roles
{
    public class RolMap : EntityTypeConfiguration<Rol>
    {
        public override void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable(nameof(Rol));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}