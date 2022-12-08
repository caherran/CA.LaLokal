using System;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.EstadosCliente
{
    public class EstadoCliente : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}