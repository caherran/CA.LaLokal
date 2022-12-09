using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDemandasCarExternas.UsuarioDemandaCarExternaCQRS.Commands.Create
{
    public class CreateUsuarioDemandaCarExternaCommandValidator : AbstractValidator<CreateUsuarioDemandaCarExternaCommand>
    {
        public CreateUsuarioDemandaCarExternaCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.UsuarioDemandaId).NotEmpty();
RuleFor(p => p.CaracteristicaExternaId).NotEmpty();

        }
    }
}