using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.ProyectosInversionistas.ProyectoInversionistaCQRS.Commands.Update
{
    public class UpdateProyectoInversionistaCommandValidator : AbstractValidator<UpdateProyectoInversionistaCommand>
    {
        public UpdateProyectoInversionistaCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
RuleFor(p => p.InmuebleId).NotEmpty();
RuleFor(p => p.UsuarioInversionistaId).NotEmpty();

        }
    }
}