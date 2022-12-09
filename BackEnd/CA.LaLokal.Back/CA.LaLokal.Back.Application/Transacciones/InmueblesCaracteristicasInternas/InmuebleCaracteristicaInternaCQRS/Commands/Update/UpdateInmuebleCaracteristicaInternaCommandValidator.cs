using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesCaracteristicasInternas.InmuebleCaracteristicaInternaCQRS.Commands.Update
{
    public class UpdateInmuebleCaracteristicaInternaCommandValidator : AbstractValidator<UpdateInmuebleCaracteristicaInternaCommand>
    {
        public UpdateInmuebleCaracteristicaInternaCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
RuleFor(p => p.InmuebleId).NotEmpty();
RuleFor(p => p.CaracteristicaInternaId).NotEmpty();

        }
    }
}