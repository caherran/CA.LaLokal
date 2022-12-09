using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosExperienciasLaborales.UsuarioExperienciaLaboralCQRS.Commands.Update
{
    public class UpdateUsuarioExperienciaLaboralCommandValidator : AbstractValidator<UpdateUsuarioExperienciaLaboralCommand>
    {
        public UpdateUsuarioExperienciaLaboralCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
RuleFor(p => p.UsuarioId).NotEmpty();
RuleFor(p => p.NombreEmpresa).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.Cargo).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.Direccion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.TrabajaActualmente).NotEmpty();
RuleFor(p => p.FechaInicio).NotEmpty();
RuleFor(p => p.FechaFinalizacion).NotEmpty();

        }
    }
}