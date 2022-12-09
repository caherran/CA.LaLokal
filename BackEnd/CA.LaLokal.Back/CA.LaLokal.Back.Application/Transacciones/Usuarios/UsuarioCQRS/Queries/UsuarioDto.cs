using CA.LaLokal.Back.Application.Maestras.Ciudades.CiudadCQRS.Queries;
using CA.LaLokal.Back.Application.Maestras.EstadosUsuario.EstadoUsuarioCQRS.Queries;
using CA.LaLokal.Back.Application.Maestras.MediosCaptacion.MedioCaptacionCQRS.Queries;
using CA.LaLokal.Back.Application.Maestras.TiposIdentificacion.TipoIdentificacionCQRS.Queries;
using CA.LaLokal.Back.Application.Maestras.TiposPersona.TipoPersonaCQRS.Queries;
using CA.LaLokal.Back.Application.Maestras.TiposUsuario.TipoUsuarioCQRS.Queries;
using CA.LaLokal.Back.Domain.Transacciones.Usuarios;
using CA.Utils.AutoMapperUtils;
using System;

namespace CA.LaLokal.Back.Application.Transacciones.Usuarios.UsuarioCQRS.Queries
{
    public class UsuarioDto : IMapFrom<Usuario>
    {
        public Guid Id { get; set; }
        public int TipoUsuarioId { get; set; }
        public TipoUsuarioDto TipoUsuario { get; set; }
        public Guid UsuarioEncargadoId { get; set; }
        public UsuarioDto UsuarioEncargado { get; set; }
        public int EstadoUsuarioId { get; set; }
        public EstadoUsuarioDto EstadoUsuario { get; set; }
        public string Nombres { get; set; }
        public string ApellIdos { get; set; }
        public int TipoPersonaId { get; set; }
        public TipoPersonaDto TipoPersona { get; set; }
        public string CorreoElectronico { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int TipoIdentificacionId { get; set; }
        public TipoIdentificacionDto TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public int MedioCaptacionId { get; set; }
        public MedioCaptacionDto MedioCaptacion { get; set; }
        public string ReferidoPor { get; set; }
        public string DatosAdicionales { get; set; }
        public int CiudadId { get; set; }
        public CiudadDto Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Observaciones { get; set; }
        public string CopiaCedula { get; set; }
        public string ContratoPrestacion { get; set; }
        public string RUT { get; set; }
        public string URLFoto { get; set; }

    }
}