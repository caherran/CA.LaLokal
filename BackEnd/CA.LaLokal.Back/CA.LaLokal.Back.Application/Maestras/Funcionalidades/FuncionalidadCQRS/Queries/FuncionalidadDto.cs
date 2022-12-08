using System;
using CA.LaLokal.Back.Domain.Maestras.Funcionalidades;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Funcionalidades.FuncionalidadCQRS.Queries
{
    public class FuncionalidadDto : IMapFrom<Funcionalidad>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}