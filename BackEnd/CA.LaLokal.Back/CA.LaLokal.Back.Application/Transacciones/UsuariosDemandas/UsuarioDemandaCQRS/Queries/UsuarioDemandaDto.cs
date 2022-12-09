using CA.LaLokal.Back.Application.Maestras.Banos.BanoCQRS.Queries;
using CA.LaLokal.Back.Application.Maestras.Ciudades.CiudadCQRS.Queries;
using CA.LaLokal.Back.Application.Maestras.Garajes.GarajeCQRS.Queries;
using CA.LaLokal.Back.Application.Maestras.TiposInmueble.TipoInmuebleCQRS.Queries;
using CA.LaLokal.Back.Application.Maestras.TiposMoneda.TipoMonedaCQRS.Queries;
using CA.LaLokal.Back.Application.Maestras.TiposNegocio.TipoNegocioCQRS.Queries;
using CA.LaLokal.Back.Application.Maestras.ZonasBarrios.ZonaBarrioCQRS.Queries;
using CA.LaLokal.Back.Application.Transacciones.Usuarios.UsuarioCQRS.Queries;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDemandas;
using CA.Utils.AutoMapperUtils;
using System;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDemandas.UsuarioDemandaCQRS.Queries
{
    public class UsuarioDemandaDto : IMapFrom<UsuarioDemanda>
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public UsuarioDto Usuario { get; set; }
        public int TipoInmuebleId { get; set; }
        public TipoInmuebleDto TipoInmueble { get; set; }
        public int TipoNegocioId { get; set; }
        public TipoNegocioDto TipoNegocio { get; set; }
        public int CiudadId { get; set; }
        public CiudadDto Ciudad { get; set; }
        public int ZonaBarrioId { get; set; }
        public ZonaBarrioDto ZonaBarrio { get; set; }
        public int TipoMonedaId { get; set; }
        public TipoMonedaDto TipoMoneda { get; set; }
        public Decimal PresupuestoMinimo { get; set; }
        public Decimal PresupuestoMaximo { get; set; }
        public Decimal AreaMinima { get; set; }
        public Decimal AreaMaxima { get; set; }
        public int BanoId { get; set; }
        public BanoDto Bano { get; set; }
        public int GarajeId { get; set; }
        public GarajeDto Garaje { get; set; }
        public string DetallePropiedad { get; set; }

    }
}