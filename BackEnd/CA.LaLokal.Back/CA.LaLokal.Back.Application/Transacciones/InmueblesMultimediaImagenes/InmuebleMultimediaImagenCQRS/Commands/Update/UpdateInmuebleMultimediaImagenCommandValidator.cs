using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesMultimediaImagenes.InmuebleMultimediaImagenCQRS.Commands.Update
{
    public class UpdateInmuebleMultimediaImagenCommandValidator : AbstractValidator<UpdateInmuebleMultimediaImagenCommand>
    {
        public UpdateInmuebleMultimediaImagenCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
RuleFor(p => p.InmuebleId).NotEmpty();
RuleFor(p => p.URLImagen).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}