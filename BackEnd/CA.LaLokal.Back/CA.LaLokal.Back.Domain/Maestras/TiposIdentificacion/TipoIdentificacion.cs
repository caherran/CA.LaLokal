using System;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.TiposIdentificacion
{
    public class TipoIdentificacion : BaseEntity
    {
        public int Id { get; set; }
public string Descripcion { get; set; }

    }
}