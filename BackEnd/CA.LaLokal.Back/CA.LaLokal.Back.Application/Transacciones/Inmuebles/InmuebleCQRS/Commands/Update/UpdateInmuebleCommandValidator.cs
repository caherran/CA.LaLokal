using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.Inmuebles.InmuebleCQRS.Commands.Update
{
    public class UpdateInmuebleCommandValidator : AbstractValidator<UpdateInmuebleCommand>
    {
        public UpdateInmuebleCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
RuleFor(p => p.Nombre).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.Codigo).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.EstadoPublicacionId).NotEmpty();
RuleFor(p => p.GestorInmuebleId).NotEmpty();
RuleFor(p => p.TipoInmuebleId).NotEmpty();
RuleFor(p => p.MatriculaInmobiliaria).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.EstadoFisicoPropiedadId).NotEmpty();
RuleFor(p => p.Ano).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.EstratoId).NotEmpty();
RuleFor(p => p.AlcobaId).NotEmpty();
RuleFor(p => p.BanoId).NotEmpty();
RuleFor(p => p.GarajeId).NotEmpty();
RuleFor(p => p.PisoId).NotEmpty();
RuleFor(p => p.AreaPrivada).NotEmpty();
RuleFor(p => p.AreaConstruIda).NotEmpty();
RuleFor(p => p.AreaTotal).NotEmpty();
RuleFor(p => p.ValorGasNatural).NotEmpty();
RuleFor(p => p.ValorTelefoniaInternet).NotEmpty();
RuleFor(p => p.ValorEnergia).NotEmpty();
RuleFor(p => p.ValorAgua).NotEmpty();
RuleFor(p => p.CiudadId).NotEmpty();
RuleFor(p => p.ZonaBarrioId).NotEmpty();
RuleFor(p => p.CodigoPostal).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.Direccion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.NoPublicar).NotEmpty();
RuleFor(p => p.SoloZona).NotEmpty();
RuleFor(p => p.PuntoExacto).NotEmpty();
RuleFor(p => p.DireccionMapa).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.Observaciones).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}