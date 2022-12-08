using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.CaracteristicasExternas.CaracteristicaExternaCQRS.Commands.Update
{
    public class UpdateCaracteristicaExternaCommandValidator : AbstractValidator<UpdateCaracteristicaExternaCommand>
    {
        public UpdateCaracteristicaExternaCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}