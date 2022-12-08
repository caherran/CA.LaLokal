using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CA.LaLokal.Back.Domain.Maestras.ZonasGeografias;
using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.ZonasGeografias
{
    public class ZonaGeograficaMap : EntityTypeConfiguration<ZonaGeografica>
    {
        public override void Configure(EntityTypeBuilder<ZonaGeografica> builder)
        {
            builder.ToTable(nameof(ZonaGeografica));

            base.Configure(builder);
        }
    }
}