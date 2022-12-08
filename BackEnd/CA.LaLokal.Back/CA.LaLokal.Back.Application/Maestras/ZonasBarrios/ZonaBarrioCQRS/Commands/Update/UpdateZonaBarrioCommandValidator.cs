using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.ZonasBarrios.ZonaBarrioCQRS.Commands.Update
{
    public class UpdateZonaBarrioCommandValidator : AbstractValidator<UpdateZonaBarrioCommand>
    {
        public UpdateZonaBarrioCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.CiudadId).NotEmpty();
            RuleFor(p => p.Codigo).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
            RuleFor(p => p.Nombre).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}