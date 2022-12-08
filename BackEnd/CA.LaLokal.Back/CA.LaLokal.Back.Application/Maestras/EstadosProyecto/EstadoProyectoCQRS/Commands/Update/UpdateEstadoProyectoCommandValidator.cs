using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.EstadosProyecto.EstadoProyectoCQRS.Commands.Update
{
    public class UpdateEstadoProyectoCommandValidator : AbstractValidator<UpdateEstadoProyectoCommand>
    {
        public UpdateEstadoProyectoCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}