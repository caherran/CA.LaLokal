using System;
using CA.LaLokal.Back.Domain.Maestras.Portales;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Portales.PortalCQRS.Queries
{
    public class PortalDto : IMapFrom<Portal>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string URLPortal { get; set; }
        public string Estatus { get; set; }

    }
}