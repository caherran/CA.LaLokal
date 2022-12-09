using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.ProyectosDocumentos.ProyectoDocumentoCQRS.Commands.Update
{
    public class UpdateProyectoDocumentoCommandValidator : AbstractValidator<UpdateProyectoDocumentoCommand>
    {
        public UpdateProyectoDocumentoCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
RuleFor(p => p.InmuebleId).NotEmpty();
RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.URLDocumento).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}