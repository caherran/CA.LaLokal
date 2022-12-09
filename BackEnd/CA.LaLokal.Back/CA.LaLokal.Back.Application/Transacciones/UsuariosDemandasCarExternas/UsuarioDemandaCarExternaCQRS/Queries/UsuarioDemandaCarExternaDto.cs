using CA.LaLokal.Back.Application.Maestras.CaracteristicasExternas.CaracteristicaExternaCQRS.Queries;
using CA.LaLokal.Back.Application.Transacciones.UsuariosDemandas.UsuarioDemandaCQRS.Queries;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDemandasCarExternas;
using CA.Utils.AutoMapperUtils;
using System;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDemandasCarExternas.UsuarioDemandaCarExternaCQRS.Queries
{
    public class UsuarioDemandaCarExternaDto : IMapFrom<UsuarioDemandaCarExterna>
    {
        public Guid Id { get; set; }
        public Guid UsuarioDemandaId { get; set; }
        public UsuarioDemandaDto UsuarioDemanda { get; set; }
        public int CaracteristicaExternaId { get; set; }
        public CaracteristicaExternaDto CaracteristicaExterna { get; set; }

    }
}