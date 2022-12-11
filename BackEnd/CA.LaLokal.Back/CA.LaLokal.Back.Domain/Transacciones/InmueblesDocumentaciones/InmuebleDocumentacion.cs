using CA.Domain.Auditable;
using CA.LaLokal.Back.Domain.Transacciones.Inmuebles;
using System;

namespace CA.LaLokal.Back.Domain.Transacciones.InmueblesDocumentaciones
{
    public class InmuebleDocumentacion : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid InmuebleId { get; set; }
        public virtual Inmueble Inmueble { get; set; }
        public string CopiaCedula { get; set; }
        public string CertificadoCamaraComercio { get; set; }
        public string CopiaEscrituraCompraventa { get; set; }
        public string CopiaPromesaCompraventa { get; set; }
        public string RUT { get; set; }
        public string CertificadoLibertad { get; set; }
        public string UltimoPagoImpuestoPredial { get; set; }
        public string CopiaRecibosServiciosPublicosPagos { get; set; }
        public string PazSalvoAdministración { get; set; }
        public string FirmaContratoAdministración { get; set; }
        public string EntregaCartaInstrucciones { get; set; }
        public string ContratoCompraAlquiler { get; set; }
    }
}