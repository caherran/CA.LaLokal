using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.TiposCliente.TipoClienteCQRS.Commands.Update
{
    public class UpdateTipoClienteCommandValidator : AbstractValidator<UpdateTipoClienteCommand>
    {
        public UpdateTipoClienteCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}