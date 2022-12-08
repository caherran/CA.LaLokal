using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.TiposUsuario.TipoUsuarioCQRS.Commands.Create
{
    public class CreateTipoUsuarioCommandValidator : AbstractValidator<CreateTipoUsuarioCommand>
    {
        public CreateTipoUsuarioCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}