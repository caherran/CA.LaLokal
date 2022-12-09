using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.TiposIdentificacion.TipoIdentificacionCQRS.Commands.Create
{
    public class CreateTipoIdentificacionCommandValidator : AbstractValidator<CreateTipoIdentificacionCommand>
    {
        public CreateTipoIdentificacionCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}