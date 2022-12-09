using CA.LaLokal.Back.Application.Transacciones.Usuarios.UsuarioCQRS.Queries;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosExperienciasLaborales;
using CA.Utils.AutoMapperUtils;
using System;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosExperienciasLaborales.UsuarioExperienciaLaboralCQRS.Queries
{
    public class UsuarioExperienciaLaboralDto : IMapFrom<UsuarioExperienciaLaboral>
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public UsuarioDto Usuario { get; set; }
        public string NombreEmpresa { get; set; }
        public string Cargo { get; set; }
        public string Direccion { get; set; }
        public bool TrabajaActualmente { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }

    }
}