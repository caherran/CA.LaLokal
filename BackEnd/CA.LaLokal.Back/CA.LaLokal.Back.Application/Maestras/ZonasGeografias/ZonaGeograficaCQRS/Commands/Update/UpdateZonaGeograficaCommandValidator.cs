using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.ZonasGeografias.ZonaGeograficaCQRS.Commands.Update
{
    public class UpdateZonaGeograficaCommandValidator : AbstractValidator<UpdateZonaGeograficaCommand>
    {
        public UpdateZonaGeograficaCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.ZonaBarrioId).NotEmpty();

        }
    }
}