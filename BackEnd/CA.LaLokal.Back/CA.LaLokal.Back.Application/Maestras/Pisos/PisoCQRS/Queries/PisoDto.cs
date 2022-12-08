using System;
using CA.LaLokal.Back.Domain.Maestras.Pisos;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Pisos.PisoCQRS.Queries
{
    public class PisoDto : IMapFrom<Piso>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}