using System;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.TiposPago
{
    public class TipoPago : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}