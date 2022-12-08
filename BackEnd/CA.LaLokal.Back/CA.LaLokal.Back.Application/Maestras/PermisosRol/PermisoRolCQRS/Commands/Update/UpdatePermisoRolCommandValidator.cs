using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.PermisosRol.PermisoRolCQRS.Commands.Update
{
    public class UpdatePermisoRolCommandValidator : AbstractValidator<UpdatePermisoRolCommand>
    {
        public UpdatePermisoRolCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.RolId).NotEmpty();
            RuleFor(p => p.PermisoId).NotEmpty();
            RuleFor(p => p.Estatus).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}