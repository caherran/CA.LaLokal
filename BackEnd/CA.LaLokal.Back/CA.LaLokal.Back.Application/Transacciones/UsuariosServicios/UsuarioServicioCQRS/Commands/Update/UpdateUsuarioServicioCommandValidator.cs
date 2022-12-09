using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosServicios.UsuarioServicioCQRS.Commands.Update
{
    public class UpdateUsuarioServicioCommandValidator : AbstractValidator<UpdateUsuarioServicioCommand>
    {
        public UpdateUsuarioServicioCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
RuleFor(p => p.UsuarioId).NotEmpty();
RuleFor(p => p.ServicioId).NotEmpty();

        }
    }
}