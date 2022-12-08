using System;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.TiposUsuario
{
    public class TipoUsuario : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}