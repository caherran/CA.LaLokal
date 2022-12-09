using CA.LaLokal.Back.Application.Transacciones.Inmuebles.InmuebleCQRS.Queries;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesMultimediaImagenes;
using CA.Utils.AutoMapperUtils;
using System;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesMultimediaImagenes.InmuebleMultimediaImagenCQRS.Queries
{
    public class InmuebleMultimediaImagenDto : IMapFrom<InmuebleMultimediaImagen>
    {
        public Guid Id { get; set; }
        public Guid InmuebleId { get; set; }
        public InmuebleDto Inmueble { get; set; }
        public string URLImagen { get; set; }

    }
}