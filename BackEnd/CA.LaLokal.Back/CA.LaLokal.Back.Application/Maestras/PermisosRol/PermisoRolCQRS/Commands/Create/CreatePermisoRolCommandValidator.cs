using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.PermisosRol.PermisoRolCQRS.Commands.Create
{
    public class CreatePermisoRolCommandValidator : AbstractValidator<CreatePermisoRolCommand>
    {
        public CreatePermisoRolCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.RolId).NotEmpty();
            RuleFor(p => p.PermisoId).NotEmpty();
            RuleFor(p => p.Estatus).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}