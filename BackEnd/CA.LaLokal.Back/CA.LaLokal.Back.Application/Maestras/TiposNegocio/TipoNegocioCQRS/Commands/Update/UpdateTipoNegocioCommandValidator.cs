using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.TiposNegocio.TipoNegocioCQRS.Commands.Update
{
    public class UpdateTipoNegocioCommandValidator : AbstractValidator<UpdateTipoNegocioCommand>
    {
        public UpdateTipoNegocioCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}