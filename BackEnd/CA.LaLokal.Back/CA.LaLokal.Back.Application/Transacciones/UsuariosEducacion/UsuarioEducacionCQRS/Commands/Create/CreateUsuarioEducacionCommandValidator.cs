using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosEducacion.UsuarioEducacionCQRS.Commands.Create
{
    public class CreateUsuarioEducacionCommandValidator : AbstractValidator<CreateUsuarioEducacionCommand>
    {
        public CreateUsuarioEducacionCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.UsuarioId).NotEmpty();
RuleFor(p => p.Titulo).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.InstitucionUniversidad).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.Direccion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.EstudiaActualmente).NotEmpty();
RuleFor(p => p.FechaInicio).NotEmpty();
RuleFor(p => p.FechaFinalizacion).NotEmpty();

        }
    }
}