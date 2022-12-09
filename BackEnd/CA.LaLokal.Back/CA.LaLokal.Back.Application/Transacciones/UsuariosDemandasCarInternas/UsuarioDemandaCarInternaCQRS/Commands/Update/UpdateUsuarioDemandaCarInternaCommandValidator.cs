using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDemandasCarInternas.UsuarioDemandaCarInternaCQRS.Commands.Update
{
    public class UpdateUsuarioDemandaCarInternaCommandValidator : AbstractValidator<UpdateUsuarioDemandaCarInternaCommand>
    {
        public UpdateUsuarioDemandaCarInternaCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
RuleFor(p => p.UsuarioDemandaId).NotEmpty();
RuleFor(p => p.CaracteristicaInternaId).NotEmpty();

        }
    }
}