using CA.Infraestructure.EFrameworkCore.SqlServer.Mapping;
using CA.LaLokal.Back.Domain.Maestras.ZonasGeografias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA.LaLokal.Back.Infraestructure.Data.Mapping.Maestras.ZonasGeografias
{
    public class ZonaGeograficaMap : EntityTypeConfiguration<ZonaGeografica>
    {
        public override void Configure(EntityTypeBuilder<ZonaGeografica> builder)
        {
            builder.ToTable("mas_" + nameof(ZonaGeografica));
            base.Configure(builder);
        }
    }
}