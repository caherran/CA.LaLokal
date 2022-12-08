using System;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.Pisos
{
    public class Piso : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}