using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesCaracteristicasExternas.InmuebleCaracteristicaExternaCQRS.Commands.Create
{
    public class CreateInmuebleCaracteristicaExternaCommandValidator : AbstractValidator<CreateInmuebleCaracteristicaExternaCommand>
    {
        public CreateInmuebleCaracteristicaExternaCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.InmuebleId).NotEmpty();
RuleFor(p => p.CaracteristicaExternaId).NotEmpty();

        }
    }
}