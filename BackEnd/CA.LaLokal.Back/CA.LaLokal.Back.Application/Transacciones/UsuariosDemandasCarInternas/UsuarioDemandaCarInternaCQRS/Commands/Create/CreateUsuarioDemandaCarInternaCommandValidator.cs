using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDemandasCarInternas.UsuarioDemandaCarInternaCQRS.Commands.Create
{
    public class CreateUsuarioDemandaCarInternaCommandValidator : AbstractValidator<CreateUsuarioDemandaCarInternaCommand>
    {
        public CreateUsuarioDemandaCarInternaCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.UsuarioDemandaId).NotEmpty();
RuleFor(p => p.CaracteristicaInternaId).NotEmpty();

        }
    }
}