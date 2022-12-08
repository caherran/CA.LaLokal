using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.Banos
{
    public class Bano : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}