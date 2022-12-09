using CA.Util.DependencyInjection;
using FluentValidation;

namespace CA.LaLokal.Back.Application.Maestras.EstadosUsuario.EstadoUsuarioCQRS.Commands.Create
{
    public class CreateEstadoUsuarioCommandValidator : AbstractValidator<CreateEstadoUsuarioCommand>
    {
        public CreateEstadoUsuarioCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}