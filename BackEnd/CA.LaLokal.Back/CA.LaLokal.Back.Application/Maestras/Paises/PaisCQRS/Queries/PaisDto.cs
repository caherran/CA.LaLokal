using CA.LaLokal.Back.Domain.Maestras.Paises;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Paises.PaisCQRS.Queries
{
    public class PaisDto : IMapFrom<Pais>
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
    }
}