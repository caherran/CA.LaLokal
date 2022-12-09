using CA.Domain.Auditable;
using CA.LaLokal.Back.Domain.Maestras.Alcobas;
using CA.LaLokal.Back.Domain.Maestras.Banos;
using CA.LaLokal.Back.Domain.Maestras.Ciudades;
using CA.LaLokal.Back.Domain.Maestras.EstadosFisicoPropiedad;
using CA.LaLokal.Back.Domain.Maestras.EstadosPublicacion;
using CA.LaLokal.Back.Domain.Maestras.Estratos;
using CA.LaLokal.Back.Domain.Maestras.Garajes;
using CA.LaLokal.Back.Domain.Maestras.Pisos;
using CA.LaLokal.Back.Domain.Maestras.TiposInmueble;
using CA.LaLokal.Back.Domain.Maestras.ZonasBarrios;
using CA.LaLokal.Back.Domain.Transacciones.Usuarios;
using System;

namespace CA.LaLokal.Back.Domain.Transacciones.Inmuebles
{
    public class Inmueble : BaseEntity
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int EstadoPublicacionId { get; set; }
        public virtual EstadoPublicacion EstadoPublicacion { get; set; }
        public Guid GestorInmuebleId { get; set; }
        public virtual Usuario GestorInmueble { get; set; }
        public int TipoInmuebleId { get; set; }
        public virtual TipoInmueble TipoInmueble { get; set; }
        public string MatriculaInmobiliaria { get; set; }
        public int EstadoFisicoPropiedadId { get; set; }
        public virtual EstadoFisicoPropiedad EstadoFisicoPropiedad { get; set; }
        public string Ano { get; set; }
        public int EstratoId { get; set; }
        public virtual Estrato Estrato { get; set; }
        public int AlcobaId { get; set; }
        public virtual Alcoba Alcoba { get; set; }
        public int BanoId { get; set; }
        public virtual Bano Bano { get; set; }
        public int GarajeId { get; set; }
        public virtual Garaje Garaje { get; set; }
        public int PisoId { get; set; }
        public virtual Piso Piso { get; set; }
        public Decimal AreaPrivada { get; set; }
        public Decimal AreaConstruIda { get; set; }
        public Decimal AreaTotal { get; set; }
        public Decimal ValorGasNatural { get; set; }
        public Decimal ValorTelefoniaInternet { get; set; }
        public Decimal ValorEnergia { get; set; }
        public Decimal ValorAgua { get; set; }
        public int CiudadId { get; set; }
        public virtual Ciudad Ciudad { get; set; }
        public int ZonaBarrioId { get; set; }
        public virtual ZonaBarrio ZonaBarrio { get; set; }
        public string CodigoPostal { get; set; }
        public string Direccion { get; set; }
        public bool NoPublicar { get; set; }
        public bool SoloZona { get; set; }
        public bool PuntoExacto { get; set; }
        public string DireccionMapa { get; set; }
        public string Observaciones { get; set; }

    }
}