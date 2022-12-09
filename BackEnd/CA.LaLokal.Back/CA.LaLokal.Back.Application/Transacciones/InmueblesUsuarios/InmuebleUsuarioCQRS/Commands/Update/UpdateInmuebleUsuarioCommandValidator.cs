using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesUsuarios.InmuebleUsuarioCQRS.Commands.Update
{
    public class UpdateInmuebleUsuarioCommandValidator : AbstractValidator<UpdateInmuebleUsuarioCommand>
    {
        public UpdateInmuebleUsuarioCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
RuleFor(p => p.InmuebleId).NotEmpty();
RuleFor(p => p.UsuarioId).NotEmpty();
RuleFor(p => p.TipoClienteId).NotEmpty();

        }
    }
}