using CA.LaLokal.Back.Application.Maestras.Alcobas.AlcobaCQRS.Queries;
using CA.LaLokal.Back.Application.Maestras.Banos.BanoCQRS.Queries;
using CA.LaLokal.Back.Application.Maestras.Ciudades.CiudadCQRS.Queries;
using CA.LaLokal.Back.Application.Maestras.EstadosFisicoPropiedad.EstadoFisicoPropiedadCQRS.Queries;
using CA.LaLokal.Back.Application.Maestras.EstadosPublicacion.EstadoPublicacionCQRS.Queries;
using CA.LaLokal.Back.Application.Maestras.Estratos.EstratoCQRS.Queries;
using CA.LaLokal.Back.Application.Maestras.Garajes.GarajeCQRS.Queries;
using CA.LaLokal.Back.Application.Maestras.Pisos.PisoCQRS.Queries;
using CA.LaLokal.Back.Application.Maestras.TiposInmueble.TipoInmuebleCQRS.Queries;
using CA.LaLokal.Back.Application.Maestras.ZonasBarrios.ZonaBarrioCQRS.Queries;
using CA.LaLokal.Back.Application.Transacciones.Usuarios.UsuarioCQRS.Queries;
using CA.LaLokal.Back.Domain.Transacciones.Inmuebles;
using CA.Utils.AutoMapperUtils;
using System;

namespace CA.LaLokal.Back.Application.Transacciones.Inmuebles.InmuebleCQRS.Queries
{
    public class InmuebleDto : IMapFrom<Inmueble>
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int EstadoPublicacionId { get; set; }
        public EstadoPublicacionDto EstadoPublicacion { get; set; }
        public Guid GestorInmuebleId { get; set; }
        public UsuarioDto GestorInmueble { get; set; }
        public int TipoInmuebleId { get; set; }
        public TipoInmuebleDto TipoInmueble { get; set; }
        public string MatriculaInmobiliaria { get; set; }
        public int EstadoFisicoPropiedadId { get; set; }
        public EstadoFisicoPropiedadDto EstadoFisicoPropiedad { get; set; }
        public string Ano { get; set; }
        public int EstratoId { get; set; }
        public EstratoDto Estrato { get; set; }
        public int AlcobaId { get; set; }
        public AlcobaDto Alcoba { get; set; }
        public int BanoId { get; set; }
        public BanoDto Bano { get; set; }
        public int GarajeId { get; set; }
        public GarajeDto Garaje { get; set; }
        public int PisoId { get; set; }
        public PisoDto Piso { get; set; }
        public Decimal AreaPrivada { get; set; }
        public Decimal AreaConstruIda { get; set; }
        public Decimal AreaTotal { get; set; }
        public Decimal ValorGasNatural { get; set; }
        public Decimal ValorTelefoniaInternet { get; set; }
        public Decimal ValorEnergia { get; set; }
        public Decimal ValorAgua { get; set; }
        public int CiudadId { get; set; }
        public CiudadDto Ciudad { get; set; }
        public int ZonaBarrioId { get; set; }
        public ZonaBarrioDto ZonaBarrio { get; set; }
        public string CodigoPostal { get; set; }
        public string Direccion { get; set; }
        public bool NoPublicar { get; set; }
        public bool SoloZona { get; set; }
        public bool PuntoExacto { get; set; }
        public string DireccionMapa { get; set; }
        public string Observaciones { get; set; }

    }
}