using System;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.EstadosFisicoPropiedad
{
    public class EstadoFisicoPropiedad : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}