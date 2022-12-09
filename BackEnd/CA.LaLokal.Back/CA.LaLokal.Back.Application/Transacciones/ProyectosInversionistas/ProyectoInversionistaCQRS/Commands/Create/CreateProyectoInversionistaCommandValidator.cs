using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.ProyectosInversionistas.ProyectoInversionistaCQRS.Commands.Create
{
    public class CreateProyectoInversionistaCommandValidator : AbstractValidator<CreateProyectoInversionistaCommand>
    {
        public CreateProyectoInversionistaCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.InmuebleId).NotEmpty();
RuleFor(p => p.UsuarioInversionistaId).NotEmpty();

        }
    }
}