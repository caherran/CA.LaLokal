using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.ZonasBarrios.ZonaBarrioCQRS.Commands.Create
{
    public class CreateZonaBarrioCommandValidator : AbstractValidator<CreateZonaBarrioCommand>
    {
        public CreateZonaBarrioCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.CiudadId).NotEmpty();
            RuleFor(p => p.Codigo).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
            RuleFor(p => p.Nombre).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}