using CA.Util.DependencyInjection;
using FluentValidation;

namespace CA.LaLokal.Back.Application.Maestras.EstadosUsuario.EstadoUsuarioCQRS.Commands.Update
{
    public class UpdateEstadoUsuarioCommandValidator : AbstractValidator<UpdateEstadoUsuarioCommand>
    {
        public UpdateEstadoUsuarioCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}