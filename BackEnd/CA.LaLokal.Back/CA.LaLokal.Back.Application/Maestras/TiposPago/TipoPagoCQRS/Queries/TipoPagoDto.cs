using System;
using CA.LaLokal.Back.Domain.Maestras.TiposPago;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposPago.TipoPagoCQRS.Queries
{
    public class TipoPagoDto : IMapFrom<TipoPago>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}