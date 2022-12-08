using System;
using CA.LaLokal.Back.Domain.Maestras.Banos;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Banos.BanoCQRS.Queries
{
    public class BanoDto : IMapFrom<Bano>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}