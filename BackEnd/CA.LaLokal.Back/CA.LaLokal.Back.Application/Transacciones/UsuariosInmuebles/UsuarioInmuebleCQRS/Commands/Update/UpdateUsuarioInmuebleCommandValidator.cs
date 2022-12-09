using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosInmuebles.UsuarioInmuebleCQRS.Commands.Update
{
    public class UpdateUsuarioInmuebleCommandValidator : AbstractValidator<UpdateUsuarioInmuebleCommand>
    {
        public UpdateUsuarioInmuebleCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
RuleFor(p => p.UsuarioId).NotEmpty();
RuleFor(p => p.InmuebleId).NotEmpty();

        }
    }
}