using CA.LaLokal.Back.Application.Maestras.Paises.PaisCQRS.Queries;
using CA.LaLokal.Back.Domain.Maestras.Departamentos;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Departamentos.DepartamentoCQRS.Queries
{
    public class DepartamentoDto : IMapFrom<Departamento>
    {
        public int Id { get; set; }
        public int PaisId { get; set; }
        public PaisDto Pais { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

    }
}