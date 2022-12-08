using System;
using CA.LaLokal.Back.Domain.Maestras.Alcobas;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Alcobas.AlcobaCQRS.Queries
{
    public class AlcobaDto : IMapFrom<Alcoba>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}