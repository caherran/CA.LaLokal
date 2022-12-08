using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.Banos.BanoCQRS.Commands.Create
{
    public class CreateBanoCommandValidator : AbstractValidator<CreateBanoCommand>
    {
        public CreateBanoCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}