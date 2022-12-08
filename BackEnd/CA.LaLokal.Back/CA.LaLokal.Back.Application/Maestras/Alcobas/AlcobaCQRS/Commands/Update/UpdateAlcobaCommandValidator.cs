using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.Alcobas.AlcobaCQRS.Commands.Update
{
    public class UpdateAlcobaCommandValidator : AbstractValidator<UpdateAlcobaCommand>
    {
        public UpdateAlcobaCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}