using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosMultimedia.UsuarioMultimediaCQRS.Commands.Update
{
    public class UpdateUsuarioMultimediaCommandValidator : AbstractValidator<UpdateUsuarioMultimediaCommand>
    {
        public UpdateUsuarioMultimediaCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
RuleFor(p => p.UsuarioId).NotEmpty();
RuleFor(p => p.URLImagen).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}