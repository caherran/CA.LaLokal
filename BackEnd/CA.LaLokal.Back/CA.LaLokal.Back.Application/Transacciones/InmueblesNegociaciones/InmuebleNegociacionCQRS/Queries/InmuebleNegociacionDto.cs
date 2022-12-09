using CA.LaLokal.Back.Application.Maestras.Tiempos.TiempoCQRS.Queries;
using CA.LaLokal.Back.Application.Maestras.TiposMoneda.TipoMonedaCQRS.Queries;
using CA.LaLokal.Back.Application.Maestras.TiposNegocio.TipoNegocioCQRS.Queries;
using CA.LaLokal.Back.Application.Transacciones.Inmuebles.InmuebleCQRS.Queries;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesNegociaciones;
using CA.Utils.AutoMapperUtils;
using System;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesNegociaciones.InmuebleNegociacionCQRS.Queries
{
    public class InmuebleNegociacionDto : IMapFrom<InmuebleNegociacion>
    {
        public Guid Id { get; set; }
        public Guid InmuebleId { get; set; }
        public InmuebleDto Inmueble { get; set; }
        public int TipoNegocioId { get; set; }
        public TipoNegocioDto TipoNegocio { get; set; }
        public int TipoMonedaId { get; set; }
        public TipoMonedaDto TipoMoneda { get; set; }
        public Decimal PrecioVenta { get; set; }
        public Decimal PrecioAlquiler { get; set; }
        public int TiempoId { get; set; }
        public TiempoDto Tiempo { get; set; }
        public Decimal ValorAdministracion { get; set; }
        public bool TienePorcentajePrecio { get; set; }
        public Decimal ValorPorcentajePrecio { get; set; }
        public bool TieneCantIdadFija { get; set; }
        public Decimal ValorCantIdadFija { get; set; }
        public bool TieneContratoExclusivIdad { get; set; }
        public DateTime FechaExpiracionContrato { get; set; }

    }
}