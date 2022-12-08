using System;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.TiposPersona
{
    public class TipoPersona : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}