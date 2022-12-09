using CA.LaLokal.Back.Application.Maestras.CaracteristicasInternas.CaracteristicaInternaCQRS.Queries;
using CA.LaLokal.Back.Application.Transacciones.UsuariosDemandas.UsuarioDemandaCQRS.Queries;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDemandasCarInternas;
using CA.Utils.AutoMapperUtils;
using System;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDemandasCarInternas.UsuarioDemandaCarInternaCQRS.Queries
{
    public class UsuarioDemandaCarInternaDto : IMapFrom<UsuarioDemandaCarInterna>
    {
        public Guid Id { get; set; }
        public Guid UsuarioDemandaId { get; set; }
        public UsuarioDemandaDto UsuarioDemanda { get; set; }
        public int CaracteristicaInternaId { get; set; }
        public CaracteristicaInternaDto CaracteristicaInterna { get; set; }

    }
}