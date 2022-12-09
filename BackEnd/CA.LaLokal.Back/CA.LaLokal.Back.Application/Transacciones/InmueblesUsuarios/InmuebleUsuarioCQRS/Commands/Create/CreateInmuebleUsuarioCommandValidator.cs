using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesUsuarios.InmuebleUsuarioCQRS.Commands.Create
{
    public class CreateInmuebleUsuarioCommandValidator : AbstractValidator<CreateInmuebleUsuarioCommand>
    {
        public CreateInmuebleUsuarioCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.InmuebleId).NotEmpty();
RuleFor(p => p.UsuarioId).NotEmpty();
RuleFor(p => p.TipoClienteId).NotEmpty();

        }
    }
}