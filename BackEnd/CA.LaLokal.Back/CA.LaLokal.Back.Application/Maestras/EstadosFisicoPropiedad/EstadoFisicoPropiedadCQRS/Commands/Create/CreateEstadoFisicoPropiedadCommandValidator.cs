using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.EstadosFisicoPropiedad.EstadoFisicoPropiedadCQRS.Commands.Create
{
    public class CreateEstadoFisicoPropiedadCommandValidator : AbstractValidator<CreateEstadoFisicoPropiedadCommand>
    {
        public CreateEstadoFisicoPropiedadCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}