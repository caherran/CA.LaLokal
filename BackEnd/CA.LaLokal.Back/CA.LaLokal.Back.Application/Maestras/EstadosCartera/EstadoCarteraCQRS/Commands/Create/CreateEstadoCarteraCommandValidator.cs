using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.EstadosCartera.EstadoCarteraCQRS.Commands.Create
{
    public class CreateEstadoCarteraCommandValidator : AbstractValidator<CreateEstadoCarteraCommand>
    {
        public CreateEstadoCarteraCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}