using System;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.CaracteristicasInternas
{
    public class CaracteristicaInterna : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}