using System;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.Funcionalidades
{
    public class Funcionalidad : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}