using System;
using CA.LaLokal.Back.Domain.Maestras.EstadosCartera;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosCartera.EstadoCarteraCQRS.Queries
{
    public class EstadoCarteraDto : IMapFrom<EstadoCartera>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}