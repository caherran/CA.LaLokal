using System;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.Garajes
{
    public class Garaje : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}