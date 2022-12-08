using System;
using CA.LaLokal.Back.Domain.Maestras.Garajes;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Garajes.GarajeCQRS.Queries
{
    public class GarajeDto : IMapFrom<Garaje>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}