using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.Permisos.PermisoCQRS.Commands.Update
{
    public class UpdatePermisoCommandValidator : AbstractValidator<UpdatePermisoCommand>
    {
        public UpdatePermisoCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
            RuleFor(p => p.FuncionalIdadId).NotEmpty();

        }
    }
}