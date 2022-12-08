using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.TiposPago.TipoPagoCQRS.Commands.Create
{
    public class CreateTipoPagoCommandValidator : AbstractValidator<CreateTipoPagoCommand>
    {
        public CreateTipoPagoCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}