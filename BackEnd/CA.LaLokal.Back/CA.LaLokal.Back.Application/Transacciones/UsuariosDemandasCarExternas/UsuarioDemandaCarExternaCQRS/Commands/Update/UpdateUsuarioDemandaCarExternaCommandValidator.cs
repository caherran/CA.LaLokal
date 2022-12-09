using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDemandasCarExternas.UsuarioDemandaCarExternaCQRS.Commands.Update
{
    public class UpdateUsuarioDemandaCarExternaCommandValidator : AbstractValidator<UpdateUsuarioDemandaCarExternaCommand>
    {
        public UpdateUsuarioDemandaCarExternaCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
RuleFor(p => p.UsuarioDemandaId).NotEmpty();
RuleFor(p => p.CaracteristicaExternaId).NotEmpty();

        }
    }
}