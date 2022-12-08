using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.TiposCliente.TipoClienteCQRS.Commands.Create
{
    public class CreateTipoClienteCommandValidator : AbstractValidator<CreateTipoClienteCommand>
    {
        public CreateTipoClienteCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}