using System;
using CA.LaLokal.Back.Domain.Maestras.CaracteristicasExternas;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.CaracteristicasExternas.CaracteristicaExternaCQRS.Queries
{
    public class CaracteristicaExternaDto : IMapFrom<CaracteristicaExterna>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}