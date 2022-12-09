using CA.Domain.Auditable;
using CA.LaLokal.Back.Domain.Maestras.Ciudades;
using CA.LaLokal.Back.Domain.Maestras.EstadosUsuario;
using CA.LaLokal.Back.Domain.Maestras.MediosCaptacion;
using CA.LaLokal.Back.Domain.Maestras.TiposIdentificacion;
using CA.LaLokal.Back.Domain.Maestras.TiposPersona;
using CA.LaLokal.Back.Domain.Maestras.TiposUsuario;
using System;

namespace CA.LaLokal.Back.Domain.Transacciones.Usuarios
{
    public class Usuario : BaseEntity
    {
        public Guid Id { get; set; }
        public int TipoUsuarioId { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }
        public Guid UsuarioEncargadoId { get; set; }
        public virtual Usuario UsuarioEncargado { get; set; }
        public int EstadoUsuarioId { get; set; }
        public virtual EstadoUsuario EstadoUsuario { get; set; }
        public string Nombres { get; set; }
        public string ApellIdos { get; set; }
        public int TipoPersonaId { get; set; }
        public virtual TipoPersona TipoPersona { get; set; }
        public string CorreoElectronico { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int TipoIdentificacionId { get; set; }
        public virtual TipoIdentificacion TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public int MedioCaptacionId { get; set; }
        public virtual MedioCaptacion MedioCaptacion { get; set; }
        public string ReferidoPor { get; set; }
        public string DatosAdicionales { get; set; }
        public int CiudadId { get; set; }
        public virtual Ciudad Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Observaciones { get; set; }
        public string CopiaCedula { get; set; }
        public string ContratoPrestacion { get; set; }
        public string RUT { get; set; }
        public string URLFoto { get; set; }

    }
}