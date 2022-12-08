using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.Portales.PortalCQRS.Commands.Update
{
    public class UpdatePortalCommandValidator : AbstractValidator<UpdatePortalCommand>
    {
        public UpdatePortalCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Nombre).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
            RuleFor(p => p.URLPortal).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
            RuleFor(p => p.Estatus).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}