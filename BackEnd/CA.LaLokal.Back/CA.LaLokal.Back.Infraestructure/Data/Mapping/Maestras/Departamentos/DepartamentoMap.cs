using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.LaLokal.Back.Domain.Maestras.Departamentos;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.Departamentos
{
    public class DepartamentoMap : EntityTypeConfiguration<Departamento>
    {
        public override void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable(nameof(Departamento));
            builder.Property(p => p.Codigo).IsRequired().HasMaxLength(80); builder.Property(p => p.Nombre).IsRequired().HasMaxLength(80);
            base.Configure(builder);
        }
    }
}