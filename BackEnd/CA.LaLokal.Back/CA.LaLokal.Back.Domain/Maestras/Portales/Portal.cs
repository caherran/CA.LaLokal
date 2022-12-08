using System;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.Portales
{
    public class Portal : BaseEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string URLPortal { get; set; }
        public string Estatus { get; set; }

    }
}