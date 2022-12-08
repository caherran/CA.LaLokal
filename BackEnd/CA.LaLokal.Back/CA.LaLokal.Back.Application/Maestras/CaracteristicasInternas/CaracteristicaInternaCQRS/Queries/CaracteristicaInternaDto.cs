using System;
using CA.LaLokal.Back.Domain.Maestras.CaracteristicasInternas;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.CaracteristicasInternas.CaracteristicaInternaCQRS.Queries
{
    public class CaracteristicaInternaDto : IMapFrom<CaracteristicaInterna>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}