using System;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.EstadosProyecto
{
    public class EstadoProyecto : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}