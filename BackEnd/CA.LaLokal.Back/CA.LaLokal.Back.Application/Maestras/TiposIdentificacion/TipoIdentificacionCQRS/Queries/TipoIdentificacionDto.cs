using System;
using CA.LaLokal.Back.Domain.Maestras.TiposIdentificacion;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposIdentificacion.TipoIdentificacionCQRS.Queries
{
    public class TipoIdentificacionDto : IMapFrom<TipoIdentificacion>
    {
        public int Id { get; set; }
public string Descripcion { get; set; }

    }
}