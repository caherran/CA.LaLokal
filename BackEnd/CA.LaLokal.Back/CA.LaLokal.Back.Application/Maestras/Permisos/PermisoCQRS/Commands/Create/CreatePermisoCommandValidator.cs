using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Maestras.Permisos.PermisoCQRS.Commands.Create
{
    public class CreatePermisoCommandValidator : AbstractValidator<CreatePermisoCommand>
    {
        public CreatePermisoCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
            RuleFor(p => p.FuncionalIdadId).NotEmpty();

        }
    }
}