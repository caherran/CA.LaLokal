using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.MediosCaptacion.MedioCaptacionCQRS.Commands.Update
{
    public class UpdateMedioCaptacionCommandValidator : AbstractValidator<UpdateMedioCaptacionCommand>
    {
        public UpdateMedioCaptacionCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}