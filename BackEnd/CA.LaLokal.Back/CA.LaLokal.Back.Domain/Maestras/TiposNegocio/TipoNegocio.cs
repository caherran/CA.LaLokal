using System;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.TiposNegocio
{
    public class TipoNegocio : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}