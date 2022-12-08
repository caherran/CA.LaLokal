using System;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.Tiempos
{
    public class Tiempo : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}