using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosServicios.UsuarioServicioCQRS.Commands.Create
{
    public class CreateUsuarioServicioCommandValidator : AbstractValidator<CreateUsuarioServicioCommand>
    {
        public CreateUsuarioServicioCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.UsuarioId).NotEmpty();
RuleFor(p => p.ServicioId).NotEmpty();

        }
    }
}