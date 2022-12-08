using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.Banos.BanoCQRS.Commands.Update
{
    public class UpdateBanoCommandValidator : AbstractValidator<UpdateBanoCommand>
    {
        public UpdateBanoCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}