using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.TiposPago.TipoPagoCQRS.Commands.Update
{
    public class UpdateTipoPagoCommandValidator : AbstractValidator<UpdateTipoPagoCommand>
    {
        public UpdateTipoPagoCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}