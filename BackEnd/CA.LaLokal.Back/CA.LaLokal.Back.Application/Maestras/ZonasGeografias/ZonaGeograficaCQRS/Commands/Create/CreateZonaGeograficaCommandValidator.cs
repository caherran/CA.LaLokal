using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.ZonasGeografias.ZonaGeograficaCQRS.Commands.Create
{
    public class CreateZonaGeograficaCommandValidator : AbstractValidator<CreateZonaGeograficaCommand>
    {
        public CreateZonaGeograficaCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.ZonaBarrioId).NotEmpty();

        }
    }
}