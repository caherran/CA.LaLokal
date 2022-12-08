using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.TiposNegocio.TipoNegocioCQRS.Commands.Create
{
    public class CreateTipoNegocioCommandValidator : AbstractValidator<CreateTipoNegocioCommand>
    {
        public CreateTipoNegocioCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}