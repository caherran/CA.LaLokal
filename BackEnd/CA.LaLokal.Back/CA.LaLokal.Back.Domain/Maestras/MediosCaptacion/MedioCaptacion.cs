using System;
using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.MediosCaptacion
{
    public class MedioCaptacion : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}