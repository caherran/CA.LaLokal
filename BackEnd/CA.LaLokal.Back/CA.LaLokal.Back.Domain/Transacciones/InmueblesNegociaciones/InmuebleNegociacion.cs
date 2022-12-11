using CA.Domain.Auditable;
using CA.LaLokal.Back.Domain.Maestras.Tiempos;
using CA.LaLokal.Back.Domain.Maestras.TiposMoneda;
using CA.LaLokal.Back.Domain.Maestras.TiposNegocio;
using CA.LaLokal.Back.Domain.Transacciones.Inmuebles;
using System;

namespace CA.LaLokal.Back.Domain.Transacciones.InmueblesNegociaciones
{
    public class InmuebleNegociacion : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid InmuebleId { get; set; }
        public virtual Inmueble Inmueble { get; set; }
        public int TipoNegocioId { get; set; }
        public virtual TipoNegocio TipoNegocio { get; set; }
        public int TipoMonedaId { get; set; }
        public virtual TipoMoneda TipoMoneda { get; set; }
        public Decimal PrecioVenta { get; set; }
        public Decimal PrecioAlquiler { get; set; }
        public int TiempoId { get; set; }
        public virtual Tiempo Tiempo { get; set; }
        public Decimal ValorAdministracion { get; set; }
        public bool TienePorcentajePrecio { get; set; }
        public Decimal ValorPorcentajePrecio { get; set; }
        public bool TieneCantIdadFija { get; set; }
        public Decimal ValorCantIdadFija { get; set; }
        public bool TieneContratoExclusivIdad { get; set; }
        public DateTime FechaExpiracionContrato { get; set; }
    }
}