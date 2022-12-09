using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.TiposIdentificacion.TipoIdentificacionCQRS.Commands.Update
{
    public class UpdateTipoIdentificacionCommandValidator : AbstractValidator<UpdateTipoIdentificacionCommand>
    {
        public UpdateTipoIdentificacionCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}