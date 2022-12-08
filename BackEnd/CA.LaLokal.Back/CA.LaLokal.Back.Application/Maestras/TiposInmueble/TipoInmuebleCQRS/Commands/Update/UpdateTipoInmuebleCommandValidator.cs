using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.TiposInmueble.TipoInmuebleCQRS.Commands.Update
{
    public class UpdateTipoInmuebleCommandValidator : AbstractValidator<UpdateTipoInmuebleCommand>
    {
        public UpdateTipoInmuebleCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}