using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.EstadosPublicacion.EstadoPublicacionCQRS.Commands.Update
{
    public class UpdateEstadoPublicacionCommandValidator : AbstractValidator<UpdateEstadoPublicacionCommand>
    {
        public UpdateEstadoPublicacionCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}