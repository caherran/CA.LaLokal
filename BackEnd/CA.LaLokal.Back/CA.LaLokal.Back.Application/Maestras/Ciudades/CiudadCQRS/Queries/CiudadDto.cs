using CA.LaLokal.Back.Application.Maestras.Departamentos.DepartamentoCQRS.Queries;
using CA.LaLokal.Back.Domain.Maestras.Ciudades;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Ciudades.CiudadCQRS.Queries
{
    public class CiudadDto : IMapFrom<Ciudad>
    {
        public int Id { get; set; }
        public int DepartamentoId { get; set; }
        public DepartamentoDto Departamento { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

    }
}