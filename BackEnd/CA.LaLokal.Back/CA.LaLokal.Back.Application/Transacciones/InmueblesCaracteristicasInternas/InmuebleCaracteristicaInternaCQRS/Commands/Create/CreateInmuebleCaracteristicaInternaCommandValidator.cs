using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesCaracteristicasInternas.InmuebleCaracteristicaInternaCQRS.Commands.Create
{
    public class CreateInmuebleCaracteristicaInternaCommandValidator : AbstractValidator<CreateInmuebleCaracteristicaInternaCommand>
    {
        public CreateInmuebleCaracteristicaInternaCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.InmuebleId).NotEmpty();
RuleFor(p => p.CaracteristicaInternaId).NotEmpty();

        }
    }
}