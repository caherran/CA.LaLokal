using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.EstadosCliente.EstadoClienteCQRS.Commands.Create
{
    public class CreateEstadoClienteCommandValidator : AbstractValidator<CreateEstadoClienteCommand>
    {
        public CreateEstadoClienteCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}