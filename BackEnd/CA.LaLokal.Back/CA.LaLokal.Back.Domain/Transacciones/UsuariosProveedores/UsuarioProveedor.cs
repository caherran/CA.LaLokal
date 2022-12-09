using CA.Domain.Auditable;
using CA.LaLokal.Back.Domain.Maestras.Ciudades;
using CA.LaLokal.Back.Domain.Transacciones.Usuarios;
using System;

namespace CA.LaLokal.Back.Domain.Transacciones.UsuariosProveedores
{
    public class UsuarioProveedor : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public string Foto { get; set; }
        public string Nombre { get; set; }
        public int CiudadId { get; set; }
        public virtual Ciudad Ciudad { get; set; }
        public string Descripcion { get; set; }
        public string PaginaWeb { get; set; }
        public string URLFacebook { get; set; }
        public string URLInstagram { get; set; }
        public int CategoriaId { get; set; }

    }
}