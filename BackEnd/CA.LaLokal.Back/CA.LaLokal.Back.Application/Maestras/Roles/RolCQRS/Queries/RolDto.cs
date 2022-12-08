using System;
using CA.LaLokal.Back.Domain.Maestras.Roles;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Roles.RolCQRS.Queries
{
    public class RolDto : IMapFrom<Rol>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}