using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.ProyectosInmuebles.ProyectoInmuebleCQRS.Commands.Update
{
    public class UpdateProyectoInmuebleCommandValidator : AbstractValidator<UpdateProyectoInmuebleCommand>
    {
        public UpdateProyectoInmuebleCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
RuleFor(p => p.InmuebleId).NotEmpty();

        }
    }
}