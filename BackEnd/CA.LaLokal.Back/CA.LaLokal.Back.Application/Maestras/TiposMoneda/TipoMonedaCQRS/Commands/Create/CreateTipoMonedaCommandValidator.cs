using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.TiposMoneda.TipoMonedaCQRS.Commands.Create
{
    public class CreateTipoMonedaCommandValidator : AbstractValidator<CreateTipoMonedaCommand>
    {
        public CreateTipoMonedaCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}