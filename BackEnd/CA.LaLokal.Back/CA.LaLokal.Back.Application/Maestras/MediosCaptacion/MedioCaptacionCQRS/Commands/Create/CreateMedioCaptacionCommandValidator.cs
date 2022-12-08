using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.MediosCaptacion.MedioCaptacionCQRS.Commands.Create
{
    public class CreateMedioCaptacionCommandValidator : AbstractValidator<CreateMedioCaptacionCommand>
    {
        public CreateMedioCaptacionCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}