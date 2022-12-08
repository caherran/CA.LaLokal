using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.Departamentos.DepartamentoCQRS.Commands.Create
{
    public class CreateDepartamentoCommandValidator : AbstractValidator<CreateDepartamentoCommand>
    {
        public CreateDepartamentoCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.PaisId).NotEmpty();
            RuleFor(p => p.Codigo).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
            RuleFor(p => p.Nombre).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}