using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Maestras.Funcionalidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.Funcionalidades
{
    public class FuncionalidadMap : EntityTypeConfiguration<Funcionalidad>
    {
        public override void Configure(EntityTypeBuilder<Funcionalidad> builder)
        {
            builder.ToTable("mas_" + nameof(Funcionalidad));
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}