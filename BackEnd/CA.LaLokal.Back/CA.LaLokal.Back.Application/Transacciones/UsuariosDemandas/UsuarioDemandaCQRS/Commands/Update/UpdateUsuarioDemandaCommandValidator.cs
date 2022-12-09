using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDemandas.UsuarioDemandaCQRS.Commands.Update
{
    public class UpdateUsuarioDemandaCommandValidator : AbstractValidator<UpdateUsuarioDemandaCommand>
    {
        public UpdateUsuarioDemandaCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
RuleFor(p => p.UsuarioId).NotEmpty();
RuleFor(p => p.TipoInmuebleId).NotEmpty();
RuleFor(p => p.TipoNegocioId).NotEmpty();
RuleFor(p => p.CiudadId).NotEmpty();
RuleFor(p => p.ZonaBarrioId).NotEmpty();
RuleFor(p => p.TipoMonedaId).NotEmpty();
RuleFor(p => p.PresupuestoMinimo).NotEmpty();
RuleFor(p => p.PresupuestoMaximo).NotEmpty();
RuleFor(p => p.AreaMinima).NotEmpty();
RuleFor(p => p.AreaMaxima).NotEmpty();
RuleFor(p => p.BanoId).NotEmpty();
RuleFor(p => p.GarajeId).NotEmpty();
RuleFor(p => p.DetallePropiedad).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}