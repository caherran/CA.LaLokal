using System;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.EstadosCartera
{
    public class EstadoCartera : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}