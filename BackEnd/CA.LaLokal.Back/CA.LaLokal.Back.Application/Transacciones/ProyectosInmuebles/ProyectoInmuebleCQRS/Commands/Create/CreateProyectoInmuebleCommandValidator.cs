using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.ProyectosInmuebles.ProyectoInmuebleCQRS.Commands.Create
{
    public class CreateProyectoInmuebleCommandValidator : AbstractValidator<CreateProyectoInmuebleCommand>
    {
        public CreateProyectoInmuebleCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.InmuebleId).NotEmpty();

        }
    }
}