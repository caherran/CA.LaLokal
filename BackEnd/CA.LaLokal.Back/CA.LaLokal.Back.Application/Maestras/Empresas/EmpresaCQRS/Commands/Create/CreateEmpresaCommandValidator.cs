using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.Empresas.EmpresaCQRS.Commands.Create
{
    public class CreateEmpresaCommandValidator : AbstractValidator<CreateEmpresaCommand>
    {
        public CreateEmpresaCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Nombre).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
            RuleFor(p => p.NIT).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
            RuleFor(p => p.PaisId).NotEmpty();
            RuleFor(p => p.DepartamentoId).NotEmpty();
            RuleFor(p => p.CiudadId).NotEmpty();
            RuleFor(p => p.ZonaBarrioId).NotEmpty();
            RuleFor(p => p.Direccion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
            RuleFor(p => p.NombreContacto).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
            RuleFor(p => p.CelularContacto).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
            RuleFor(p => p.CorreoElectronico).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}