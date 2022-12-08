using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.Paises.PaisCQRS.Commands.Create
{
    public class CreatePaisCommandValidator : AbstractValidator<CreatePaisCommand>
    {
        public CreatePaisCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Codigo).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}