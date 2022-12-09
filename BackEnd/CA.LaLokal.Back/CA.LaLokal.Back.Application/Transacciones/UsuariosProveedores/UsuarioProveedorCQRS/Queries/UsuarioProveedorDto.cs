using CA.LaLokal.Back.Application.Maestras.Ciudades.CiudadCQRS.Queries;
using CA.LaLokal.Back.Application.Transacciones.Usuarios.UsuarioCQRS.Queries;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosProveedores;
using CA.Utils.AutoMapperUtils;
using System;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosProveedores.UsuarioProveedorCQRS.Queries
{
    public class UsuarioProveedorDto : IMapFrom<UsuarioProveedor>
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public UsuarioDto Usuario { get; set; }
        public string Foto { get; set; }
        public string Nombre { get; set; }
        public int CiudadId { get; set; }
        public CiudadDto Ciudad { get; set; }
        public string Descripcion { get; set; }
        public string PaginaWeb { get; set; }
        public string URLFacebook { get; set; }
        public string URLInstagram { get; set; }
        public int CategoriaId { get; set; }

    }
}