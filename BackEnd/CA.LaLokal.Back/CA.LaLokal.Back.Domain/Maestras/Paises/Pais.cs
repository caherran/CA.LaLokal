using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.Paises
{
    public class Pais : BaseEntity
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
    }
}