using System;
using CA.LaLokal.Back.Domain.Maestras.EstadosFisicoPropiedad;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosFisicoPropiedad.EstadoFisicoPropiedadCQRS.Queries
{
    public class EstadoFisicoPropiedadDto : IMapFrom<EstadoFisicoPropiedad>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}