using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.Garajes.GarajeCQRS.Commands.Update
{
    public class UpdateGarajeCommandValidator : AbstractValidator<UpdateGarajeCommand>
    {
        public UpdateGarajeCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}