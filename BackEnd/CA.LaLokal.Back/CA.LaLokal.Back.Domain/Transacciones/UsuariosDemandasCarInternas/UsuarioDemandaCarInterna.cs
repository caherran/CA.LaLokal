using CA.Domain.Auditable;
using CA.LaLokal.Back.Domain.Maestras.CaracteristicasInternas;
using CA.LaLokal.Back.Domain.Transacciones.Usuarios;
using System;

namespace CA.LaLokal.Back.Domain.Transacciones.UsuariosDemandasCarInternas
{
    public class UsuarioDemandaCarInterna : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid UsuarioDemandaId { get; set; }
        public virtual Usuario UsuarioDemanda { get; set; }
        public int CaracteristicaInternaId { get; set; }
        public virtual CaracteristicaInterna CaracteristicaInterna { get; set; }

    }
}