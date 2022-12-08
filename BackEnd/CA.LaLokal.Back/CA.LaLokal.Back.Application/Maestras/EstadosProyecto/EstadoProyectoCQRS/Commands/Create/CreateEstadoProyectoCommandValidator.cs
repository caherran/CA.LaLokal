using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.EstadosProyecto.EstadoProyectoCQRS.Commands.Create
{
    public class CreateEstadoProyectoCommandValidator : AbstractValidator<CreateEstadoProyectoCommand>
    {
        public CreateEstadoProyectoCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}