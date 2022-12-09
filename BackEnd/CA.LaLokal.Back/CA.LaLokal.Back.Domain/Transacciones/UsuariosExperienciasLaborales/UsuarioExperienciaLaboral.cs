using CA.Domain.Auditable;
using CA.LaLokal.Back.Domain.Transacciones.Usuarios;
using System;

namespace CA.LaLokal.Back.Domain.Transacciones.UsuariosExperienciasLaborales
{
    public class UsuarioExperienciaLaboral : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public string NombreEmpresa { get; set; }
        public string Cargo { get; set; }
        public string Direccion { get; set; }
        public bool TrabajaActualmente { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }

    }
}