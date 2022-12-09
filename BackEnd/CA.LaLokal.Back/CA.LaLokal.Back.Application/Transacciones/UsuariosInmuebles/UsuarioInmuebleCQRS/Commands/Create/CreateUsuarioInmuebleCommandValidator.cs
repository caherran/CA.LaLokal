using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosInmuebles.UsuarioInmuebleCQRS.Commands.Create
{
    public class CreateUsuarioInmuebleCommandValidator : AbstractValidator<CreateUsuarioInmuebleCommand>
    {
        public CreateUsuarioInmuebleCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.UsuarioId).NotEmpty();
RuleFor(p => p.InmuebleId).NotEmpty();

        }
    }
}