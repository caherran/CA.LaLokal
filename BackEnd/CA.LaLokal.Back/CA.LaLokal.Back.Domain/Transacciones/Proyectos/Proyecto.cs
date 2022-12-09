using CA.Domain.Auditable;
using CA.LaLokal.Back.Domain.Maestras.EstadosProyecto;
using CA.LaLokal.Back.Domain.Maestras.TiposInmueble;
using CA.LaLokal.Back.Domain.Maestras.TiposMoneda;
using CA.LaLokal.Back.Domain.Maestras.TiposNegocio;
using CA.LaLokal.Back.Domain.Transacciones.Usuarios;
using System;

namespace CA.LaLokal.Back.Domain.Transacciones.Proyectos
{
    public class Proyecto : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid UsuarioEncargadoId { get; set; }
        public virtual Usuario UsuarioEncargado { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int EstadoProyectoId { get; set; }
        public virtual EstadoProyecto EstadoProyecto { get; set; }
        public int TipoInmuebleId { get; set; }
        public virtual TipoInmueble TipoInmueble { get; set; }
        public int TipoNegocioId { get; set; }
        public virtual TipoNegocio TipoNegocio { get; set; }
        public int TipoMonedaId { get; set; }
        public virtual TipoMoneda TipoMoneda { get; set; }
        public Decimal MontoTotal { get; set; }
        public int CantIdadInversionistas { get; set; }
        public Decimal MontoMinimoInversion { get; set; }
        public Decimal MontoMaximoInversion { get; set; }
        public Decimal RentabilIdadTotal { get; set; }
        public Decimal RentabilIdadAnalizada { get; set; }
        public string PlazoRetornoEsperado { get; set; }
        public Decimal TotalAFinanciar { get; set; }
        public Decimal CostoProyecto { get; set; }
        public Decimal IngresoEstimadoVenta { get; set; }
        public Decimal RentabilIdad { get; set; }
        public Decimal CreacionSpA { get; set; }
        public Decimal InscripciónSpA { get; set; }
        public Decimal EstudioTítulos { get; set; }
        public Decimal PromesaEscrituraCompra { get; set; }
        public Decimal InscripciónPropiedadCBR { get; set; }
        public Decimal ContabilIdadRentaAnual { get; set; }
        public Decimal ContabilIdadMensual { get; set; }
        public Decimal Contribuciones { get; set; }
        public Decimal PatenteComercialSpA { get; set; }
        public Decimal CompraTerreno { get; set; }
        public Decimal ComisiónCorretajeCompra { get; set; }
        public Decimal ProyectoParcelación { get; set; }
        public Decimal MarketingVenta { get; set; }
        public Decimal FondoReservaProyecto { get; set; }
        public Decimal PromesaEscrituraVenta { get; set; }
        public Decimal CierreSpA { get; set; }

    }
}