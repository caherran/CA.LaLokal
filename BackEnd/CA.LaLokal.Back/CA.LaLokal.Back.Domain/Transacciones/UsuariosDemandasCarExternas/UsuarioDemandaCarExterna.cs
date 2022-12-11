using CA.Domain.Auditable;
using CA.LaLokal.Back.Domain.Maestras.CaracteristicasExternas;
using CA.LaLokal.Back.Domain.Transacciones.Usuarios;
using System;

namespace CA.LaLokal.Back.Domain.Transacciones.UsuariosDemandasCarExternas
{
    public class UsuarioDemandaCarExterna : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid UsuarioDemandaId { get; set; }
        public virtual Usuario UsuarioDemanda { get; set; }
        public int CaracteristicaExternaId { get; set; }
        public virtual CaracteristicaExterna CaracteristicaExterna { get; set; }
    }
}