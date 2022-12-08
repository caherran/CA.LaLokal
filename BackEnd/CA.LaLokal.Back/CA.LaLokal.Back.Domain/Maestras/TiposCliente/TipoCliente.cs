using System;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.TiposCliente
{
    public class TipoCliente : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}