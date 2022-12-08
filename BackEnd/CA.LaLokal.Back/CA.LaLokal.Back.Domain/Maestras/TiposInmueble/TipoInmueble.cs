using System;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.TiposInmueble
{
    public class TipoInmueble : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}