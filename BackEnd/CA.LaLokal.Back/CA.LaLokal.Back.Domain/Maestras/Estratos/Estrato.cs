using System;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.Estratos
{
    public class Estrato : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}