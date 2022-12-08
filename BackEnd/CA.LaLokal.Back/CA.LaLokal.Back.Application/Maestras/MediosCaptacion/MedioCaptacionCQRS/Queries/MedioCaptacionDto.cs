using System;
using CA.LaLokal.Back.Domain.Maestras.MediosCaptacion;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.MediosCaptacion.MedioCaptacionCQRS.Queries
{
    public class MedioCaptacionDto : IMapFrom<MedioCaptacion>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }
}