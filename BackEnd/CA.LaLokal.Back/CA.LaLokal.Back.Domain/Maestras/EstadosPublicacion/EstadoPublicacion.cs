using System;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.EstadosPublicacion
{
    public class EstadoPublicacion : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}