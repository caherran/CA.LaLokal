using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.Ciudades.CiudadCQRS.Commands.Create
{
    public class CreateCiudadCommandValidator : AbstractValidator<CreateCiudadCommand>
    {
        public CreateCiudadCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.DepartamentoId).NotEmpty();
            RuleFor(p => p.Codigo).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
            RuleFor(p => p.Nombre).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}