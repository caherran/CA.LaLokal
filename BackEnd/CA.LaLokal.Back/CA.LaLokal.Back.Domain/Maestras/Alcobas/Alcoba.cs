using System;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.Alcobas
{
    public class Alcoba : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}