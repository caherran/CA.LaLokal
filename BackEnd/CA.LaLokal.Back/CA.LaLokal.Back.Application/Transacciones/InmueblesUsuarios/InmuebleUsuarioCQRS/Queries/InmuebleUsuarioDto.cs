using CA.LaLokal.Back.Application.Maestras.TiposCliente.TipoClienteCQRS.Queries;
using CA.LaLokal.Back.Application.Transacciones.Inmuebles.InmuebleCQRS.Queries;
using CA.LaLokal.Back.Application.Transacciones.Usuarios.UsuarioCQRS.Queries;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesUsuarios;
using CA.Utils.AutoMapperUtils;
using System;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesUsuarios.InmuebleUsuarioCQRS.Queries
{
    public class InmuebleUsuarioDto : IMapFrom<InmuebleUsuario>
    {
        public Guid Id { get; set; }
        public Guid InmuebleId { get; set; }
        public InmuebleDto Inmueble { get; set; }
        public Guid UsuarioId { get; set; }
        public UsuarioDto Usuario { get; set; }
        public int TipoClienteId { get; set; }
        public TipoClienteDto TipoCliente { get; set; }

    }
}