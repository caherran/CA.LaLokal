using CA.Domain.Auditable;

namespace CA.LaLokal.Back.Domain.Maestras.EstadosUsuario
{
    public class EstadoUsuario : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}