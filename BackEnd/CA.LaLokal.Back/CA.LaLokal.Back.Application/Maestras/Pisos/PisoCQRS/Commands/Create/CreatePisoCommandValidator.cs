using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.Pisos.PisoCQRS.Commands.Create
{
    public class CreatePisoCommandValidator : AbstractValidator<CreatePisoCommand>
    {
        public CreatePisoCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}