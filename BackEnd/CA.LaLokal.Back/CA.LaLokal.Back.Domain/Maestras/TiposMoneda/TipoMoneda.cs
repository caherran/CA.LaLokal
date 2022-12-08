using System;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.TiposMoneda
{
    public class TipoMoneda : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}