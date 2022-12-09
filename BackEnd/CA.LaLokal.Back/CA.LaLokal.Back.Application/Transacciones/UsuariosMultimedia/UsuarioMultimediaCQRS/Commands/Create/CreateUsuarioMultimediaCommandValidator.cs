using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosMultimedia.UsuarioMultimediaCQRS.Commands.Create
{
    public class CreateUsuarioMultimediaCommandValidator : AbstractValidator<CreateUsuarioMultimediaCommand>
    {
        public CreateUsuarioMultimediaCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.UsuarioId).NotEmpty();
RuleFor(p => p.URLImagen).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}