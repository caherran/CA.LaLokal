using CA.LaLokal.Back.Application.Transacciones.Inmuebles.InmuebleCQRS.Queries;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesDocumentaciones;
using CA.Utils.AutoMapperUtils;
using System;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesDocumentaciones.InmuebleDocumentacionCQRS.Queries
{
    public class InmuebleDocumentacionDto : IMapFrom<InmuebleDocumentacion>
    {
        public Guid Id { get; set; }
        public Guid InmuebleId { get; set; }
        public InmuebleDto Inmueble { get; set; }
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