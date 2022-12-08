using System;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.CaracteristicasExternas
{
    public class CaracteristicaExterna : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}