using System;
using CA.LaLokal.Back.Domain.Maestras.EstadosProyecto;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosProyecto.EstadoProyectoCQRS.Queries
{
    public class EstadoProyectoDto : IMapFrom<EstadoProyecto>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}