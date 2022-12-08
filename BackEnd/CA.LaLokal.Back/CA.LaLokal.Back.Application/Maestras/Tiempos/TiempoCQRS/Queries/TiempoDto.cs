using System;
using CA.LaLokal.Back.Domain.Maestras.Tiempos;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Tiempos.TiempoCQRS.Queries
{
    public class TiempoDto : IMapFrom<Tiempo>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}