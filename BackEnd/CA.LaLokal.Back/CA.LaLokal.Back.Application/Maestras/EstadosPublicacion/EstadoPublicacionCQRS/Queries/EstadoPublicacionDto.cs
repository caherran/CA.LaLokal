using System;
using CA.LaLokal.Back.Domain.Maestras.EstadosPublicacion;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosPublicacion.EstadoPublicacionCQRS.Queries
{
    public class EstadoPublicacionDto : IMapFrom<EstadoPublicacion>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}