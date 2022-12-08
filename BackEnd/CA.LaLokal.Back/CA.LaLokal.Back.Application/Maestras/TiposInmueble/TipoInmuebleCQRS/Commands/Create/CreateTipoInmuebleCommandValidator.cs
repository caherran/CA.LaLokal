using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.TiposInmueble.TipoInmuebleCQRS.Commands.Create
{
    public class CreateTipoInmuebleCommandValidator : AbstractValidator<CreateTipoInmuebleCommand>
    {
        public CreateTipoInmuebleCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}