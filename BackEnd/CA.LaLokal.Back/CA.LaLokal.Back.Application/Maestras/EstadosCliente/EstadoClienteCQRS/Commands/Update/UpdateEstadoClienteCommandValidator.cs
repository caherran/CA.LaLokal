using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.EstadosCliente.EstadoClienteCQRS.Commands.Update
{
    public class UpdateEstadoClienteCommandValidator : AbstractValidator<UpdateEstadoClienteCommand>
    {
        public UpdateEstadoClienteCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}