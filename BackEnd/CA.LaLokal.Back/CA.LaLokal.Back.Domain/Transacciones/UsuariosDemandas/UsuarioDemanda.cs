using CA.Domain.Auditable;
using CA.LaLokal.Back.Domain.Maestras.Banos;
using CA.LaLokal.Back.Domain.Maestras.Ciudades;
using CA.LaLokal.Back.Domain.Maestras.Garajes;
using CA.LaLokal.Back.Domain.Maestras.TiposInmueble;
using CA.LaLokal.Back.Domain.Maestras.TiposMoneda;
using CA.LaLokal.Back.Domain.Maestras.TiposNegocio;
using CA.LaLokal.Back.Domain.Maestras.ZonasBarrios;
using CA.LaLokal.Back.Domain.Transacciones.Usuarios;
using System;

namespace CA.LaLokal.Back.Domain.Transacciones.UsuariosDemandas
{
    public class UsuarioDemanda : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int TipoInmuebleId { get; set; }
        public virtual TipoInmueble TipoInmueble { get; set; }
        public int TipoNegocioId { get; set; }
        public virtual TipoNegocio TipoNegocio { get; set; }
        public int CiudadId { get; set; }
        public virtual Ciudad Ciudad { get; set; }
        public int ZonaBarrioId { get; set; }
        public virtual ZonaBarrio ZonaBarrio { get; set; }
        public int TipoMonedaId { get; set; }
        public virtual TipoMoneda TipoMoneda { get; set; }
        public Decimal PresupuestoMinimo { get; set; }
        public Decimal PresupuestoMaximo { get; set; }
        public Decimal AreaMinima { get; set; }
        public Decimal AreaMaxima { get; set; }
        public int BanoId { get; set; }
        public virtual Bano Bano { get; set; }
        public int GarajeId { get; set; }
        public virtual Garaje Garaje { get; set; }
        public string DetallePropiedad { get; set; }

    }
}