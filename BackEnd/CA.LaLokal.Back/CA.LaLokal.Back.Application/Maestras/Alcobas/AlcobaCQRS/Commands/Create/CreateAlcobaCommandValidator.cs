using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.Alcobas.AlcobaCQRS.Commands.Create
{
    public class CreateAlcobaCommandValidator : AbstractValidator<CreateAlcobaCommand>
    {
        public CreateAlcobaCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}