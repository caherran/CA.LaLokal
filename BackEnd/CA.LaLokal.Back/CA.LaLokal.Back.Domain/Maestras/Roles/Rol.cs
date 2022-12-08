using System;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.Roles
{
    public class Rol : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}