using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesCompartir.InmuebleCompartirCQRS.Commands.Create
{
    public class CreateInmuebleCompartirCommandValidator : AbstractValidator<CreateInmuebleCompartirCommand>
    {
        public CreateInmuebleCompartirCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.InmuebleId).NotEmpty();
RuleFor(p => p.UsuarioId).NotEmpty();
RuleFor(p => p.Asunto).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}