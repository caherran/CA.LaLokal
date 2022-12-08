using System;
using CA.LaLokal.Back.Domain.Maestras.Estratos;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Estratos.EstratoCQRS.Queries
{
    public class EstratoDto : IMapFrom<Estrato>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}