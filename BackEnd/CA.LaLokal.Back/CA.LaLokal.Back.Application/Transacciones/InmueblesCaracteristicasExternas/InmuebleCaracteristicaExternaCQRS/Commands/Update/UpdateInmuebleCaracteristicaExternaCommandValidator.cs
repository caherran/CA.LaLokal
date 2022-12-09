using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesCaracteristicasExternas.InmuebleCaracteristicaExternaCQRS.Commands.Update
{
    public class UpdateInmuebleCaracteristicaExternaCommandValidator : AbstractValidator<UpdateInmuebleCaracteristicaExternaCommand>
    {
        public UpdateInmuebleCaracteristicaExternaCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
RuleFor(p => p.InmuebleId).NotEmpty();
RuleFor(p => p.CaracteristicaExternaId).NotEmpty();

        }
    }
}