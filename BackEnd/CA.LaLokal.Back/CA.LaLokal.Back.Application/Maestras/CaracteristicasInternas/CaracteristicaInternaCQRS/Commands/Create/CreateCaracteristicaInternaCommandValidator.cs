using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.CaracteristicasInternas.CaracteristicaInternaCQRS.Commands.Create
{
    public class CreateCaracteristicaInternaCommandValidator : AbstractValidator<CreateCaracteristicaInternaCommand>
    {
        public CreateCaracteristicaInternaCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}