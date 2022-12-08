using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.Tiempos.TiempoCQRS.Commands.Create
{
    public class CreateTiempoCommandValidator : AbstractValidator<CreateTiempoCommand>
    {
        public CreateTiempoCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}