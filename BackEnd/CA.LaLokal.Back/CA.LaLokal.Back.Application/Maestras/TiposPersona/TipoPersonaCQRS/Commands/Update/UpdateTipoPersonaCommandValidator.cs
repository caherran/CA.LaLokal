using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.TiposPersona.TipoPersonaCQRS.Commands.Update
{
    public class UpdateTipoPersonaCommandValidator : AbstractValidator<UpdateTipoPersonaCommand>
    {
        public UpdateTipoPersonaCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}