using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.Estratos.EstratoCQRS.Commands.Create
{
    public class CreateEstratoCommandValidator : AbstractValidator<CreateEstratoCommand>
    {
        public CreateEstratoCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}