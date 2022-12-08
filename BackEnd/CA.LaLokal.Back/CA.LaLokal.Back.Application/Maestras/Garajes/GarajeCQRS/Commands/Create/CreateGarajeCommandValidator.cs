using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.Garajes.GarajeCQRS.Commands.Create
{
    public class CreateGarajeCommandValidator : AbstractValidator<CreateGarajeCommand>
    {
        public CreateGarajeCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}